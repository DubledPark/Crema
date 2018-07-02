﻿//Released under the MIT License.
//
//Copyright (c) 2018 Ntreev Soft co., Ltd.
//
//Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
//documentation files (the "Software"), to deal in the Software without restriction, including without limitation the 
//rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit 
//persons to whom the Software is furnished to do so, subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in all copies or substantial portions of the 
//Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE 
//WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR 
//COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR 
//OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using Ntreev.Crema.Data;
using Ntreev.Crema.ServiceModel;
using Ntreev.Crema.Services;
using Ntreev.Library;
using Ntreev.Library.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ntreev.Crema.Repository.Git
{
    class GitRepository : IRepository
    {
        private readonly string repositoryPath;
        private readonly string transactionPath;
        private readonly GitRepositoryProvider repositoryProvider;
        private readonly ILogService logService;
        private RepositoryInfo repositoryInfo;

        public GitRepository(GitRepositoryProvider repositoryProvider, ILogService logService, string repositoryPath, string transactionPath, RepositoryInfo repositoryInfo)
        {
            this.repositoryProvider = repositoryProvider;
            this.logService = logService;
            this.repositoryPath = repositoryPath;
            this.transactionPath = transactionPath;
            this.repositoryInfo = repositoryInfo;

            var items = GitHost.Run(this.repositoryPath, "status", "-s").Trim();

            if (items != string.Empty)
            {
                var sb = new StringBuilder();
                sb.AppendLine($"Repository is dirty. Please fix the problem before running the service.");
                sb.AppendLine();
                sb.AppendLine(items);
                throw new Exception($"{sb}");
            }
        }

        public RepositoryInfo RepositoryInfo => this.repositoryInfo;

        public string BasePath => this.repositoryPath;

        public void Add(string path)
        {
            if (DirectoryUtility.IsDirectory(path) == true)
            {
                var keepPath = Path.Combine(path, GitRepositoryProvider.KeepExtension);
                if (File.Exists(keepPath) == false)
                {
                    File.WriteAllText(keepPath, string.Empty);
                    GitHost.Run(this.repositoryPath, "add", keepPath.ToGitPath());
                }
            }
            else
            {
                GitHost.Run(this.repositoryPath, "add", path.ToGitPath());
            }
        }

        public void BeginTransaction(string author, string name)
        {
            throw new NotImplementedException();
        }

        public void CancelTransaction()
        {
            throw new NotImplementedException();
        }

        public void Commit(string author, string comment, params LogPropertyInfo[] properties)
        {
            var commentMessage = this.repositoryProvider.GenerateComment(comment, properties);
            //if (this.transactions.ContainsKey(path) == true)
            //{
            //    var patchPath = Path.Combine(this.transactionPath, this.transactions[path] + ".patch");
            //    var text = this.Run("diff", path.ToGitPath(), "--patch-compatible");
            //    FileUtility.WriteAllText(text, patchPath);
            //    this.transactionMessages[path] = this.transactionMessages[path] + comment + Environment.NewLine;
            //    //return DateTime.UtcNow;
            //}

            //var propText = string.Join(" ", properties.Select(item => $"--with-revprop \"{propertyPrefix}{item.Key}={item.Value}\""));

            this.logService?.Debug($"repository committing {this.repositoryPath.ToGitPath()}");
            var result = string.Empty;
            var commentPath = PathUtility.GetTempFileName();
            try
            {
                var status = GitHost.Run(this.repositoryPath, "status", "-s").Trim();
                if (status != string.Empty)
                {
                    File.WriteAllText(commentPath, commentMessage);
                    result = GitHost.Run(this.repositoryPath, "commit", "-a", "--file", $"\"{commentPath}\"");
                    GitHost.Run(this.repositoryPath, "pull");
                    GitHost.Run(this.repositoryPath, "push");
                }
            }
            catch (Exception e)
            {
                this.logService?.Warn(e);
            }
            finally
            {
                FileUtility.Delete(commentPath);
            }

            if (result.Trim() != string.Empty)
            {
                this.logService?.Debug($"repository committed {this.repositoryPath.ToGitPath()}");
                this.logService?.Debug(result);
                var userID = properties.FirstOrDefault(item => item.Key == LogPropertyInfo.UserIDKey).Value;
                var log = GitLogInfo.Run(this.repositoryPath, "--max-count=1").First();
                this.repositoryInfo.Revision = log.CommitID;
                this.repositoryInfo.ModificationInfo = new SignatureDate(userID ?? string.Empty, log.CommitDate);
            }
            else
            {
                this.logService?.Debug("repository no changes. \"{0}\"", this.repositoryPath);
            }
        }

        public void Copy(string srcPath, string toPath)
        {
            if (DirectoryUtility.IsDirectory(srcPath) == true)
            {
                throw new NotImplementedException();
            }
            else
            {
                File.Copy(srcPath, toPath);
                GitHost.Run(this.repositoryPath, "add", toPath.ToGitPath());
            }
        }

        public void Delete(string path)
        {
            if (Directory.Exists(path) == true)
            {
                GitHost.Run(this.repositoryPath, "rm", path.ToGitPath(), "-r");
            }
            else
            {
                GitHost.Run(this.repositoryPath, "rm", path.ToGitPath());
            }
        }

        public void Dispose()
        {
            DirectoryUtility.Delete(this.repositoryPath);
        }

        public void EndTransaction()
        {
            throw new NotImplementedException();
        }

        public string Export(Uri uri, string exportPath)
        {
            var match = Regex.Match(uri.LocalPath, "(?<path>.+)@(?<keep>.*)(?<revision>[a-f0-9]{40})", RegexOptions.ExplicitCapture);
            var path = match.Groups["path"].Value;
            var keep = match.Groups["keep"].Value;
            var revision = match.Groups["revision"].Value;

            var tempPath = PathUtility.GetTempFileName();
            try
            {
                if (DirectoryUtility.IsEmpty(exportPath) == true)
                    new CremaDataSet().WriteToDirectory(exportPath);
                var relativePath = UriUtility.MakeRelativeOfDirectory(this.repositoryPath, path);
                GitHost.Run(this.repositoryPath, "archive", $"--output=\"{tempPath}\"", "--format=zip", revision, "--", path.ToGitPath());
                ZipFile.ExtractToDirectory(tempPath, exportPath);
                var exportUri = new Uri(UriUtility.Combine(exportPath, relativePath));
                return exportUri.LocalPath;
            }
            finally
            {
                FileUtility.Delete(tempPath);
            }
        }

        public LogInfo[] GetLog(string[] paths, string revision, int count)
        {
            var logs = GitLogInfo.RunWithPaths(this.repositoryPath, revision, paths, $"--max-count={count}");
            return logs.Select(item => (LogInfo)item).ToArray();
        }

        public Uri GetUri(string path, string revision)
        {
            if (DirectoryUtility.IsDirectory(path) == true)
            {
                var uri = new Uri($"{path}@{revision ?? this.repositoryInfo.Revision}");
                var uriString = uri.ToString();
                var text = Regex.Replace(uriString, "file:///", "dir:///");
                return new Uri(text);
            }
            return new Uri($"{path}@{revision ?? this.repositoryInfo.Revision}");
        }

        public void Move(string srcPath, string toPath)
        {
            GitHost.Run(this.repositoryPath, "mv", srcPath.ToGitPath(), toPath.ToGitPath());
        }

        public void Revert()
        {
            GitHost.Run(this.repositoryPath, "reset", "--hard");
        }

        public void Revert(string revision)
        {
            throw new NotImplementedException();
        }

        public RepositoryItem[] Status(params string[] paths)
        {
            var items = GitItemStatusInfo.Run(this.repositoryPath, paths);
            var itemList = new List<RepositoryItem>(items.Length);
            foreach (var item in items)
            {
                var repositoryItem = new RepositoryItem()
                {
                    Path = new Uri(UriUtility.Combine(this.repositoryPath, item.Path)).LocalPath,
                    OldPath = new Uri(UriUtility.Combine(this.repositoryPath, item.OldPath)).LocalPath,
                    Status = item.Status,
                };

                itemList.Add(repositoryItem);
            }
            return itemList.ToArray();
        }
    }
}
