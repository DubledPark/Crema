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
using Ntreev.Crema.Services.Properties;
using Ntreev.Library;
using Ntreev.Library.Linq;
using Ntreev.Library.ObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ntreev.Crema.Services.Data
{
    class TypeCategory : TypeCategoryBase<Type, TypeCategory, TypeCollection, TypeCategoryCollection, TypeContext>,
        ITypeCategory, ITypeItem
    {
        private readonly List<NewTypeTemplate> templateList = new List<NewTypeTemplate>();

        public TypeCategory()
        {

        }

        public AccessType GetAccessType(Authentication authentication)
        {
            try
            {
                this.DataBase.ValidateBeginInDataBase(authentication);
                return base.GetAccessType(authentication);
            }
            catch (Exception e)
            {
                this.CremaHost.Error(e);
                throw;
            }
        }

        public bool VerifyAccessType(Authentication authentication, AccessType accessType)
        {
            try
            {
                this.DataBase.ValidateBeginInDataBase(authentication);
                return base.VerifyAccessType(authentication, accessType);
            }
            catch (Exception e)
            {
                this.CremaHost.Error(e);
                throw;
            }
        }

        public void SetPublic(Authentication authentication)
        {
            try
            {
                this.DataBase.ValidateBeginInDataBase(authentication);
                this.CremaHost.DebugMethod(authentication, this, nameof(SetPublic), this);
                base.ValidateSetPublic(authentication);
                this.Sign(authentication);
                this.Context.InvokeTypeItemSetPublic(authentication, this, this.AccessInfo);
                base.SetPublic(authentication);
                this.Context.InvokeItemsSetPublicEvent(authentication, new ITypeItem[] { this, });
            }
            catch (Exception e)
            {
                this.CremaHost.Error(e);
                throw;
            }
        }

        public void SetPrivate(Authentication authentication)
        {
            try
            {
                this.DataBase.ValidateBeginInDataBase(authentication);
                this.CremaHost.DebugMethod(authentication, this, nameof(SetPrivate), this);
                base.ValidateSetPrivate(authentication);
                this.Sign(authentication);
                this.Context.InvokeTypeItemSetPrivate(authentication, this, AccessInfo.Empty);
                base.SetPrivate(authentication);
                this.Context.InvokeItemsSetPrivateEvent(authentication, new ITypeItem[] { this, });
            }
            catch (Exception e)
            {
                this.CremaHost.Error(e);
                throw;
            }
        }

        public void AddAccessMember(Authentication authentication, string memberID, AccessType accessType)
        {
            try
            {
                this.DataBase.ValidateBeginInDataBase(authentication);
                this.CremaHost.DebugMethod(authentication, this, nameof(AddAccessMember), this, memberID, accessType);
                base.ValidateAddAccessMember(authentication, memberID, accessType);
                this.Sign(authentication);
                this.Context.InvokeTypeItemAddAccessMember(authentication, this, this.AccessInfo, memberID, accessType);
                base.AddAccessMember(authentication, memberID, accessType);
                this.Context.InvokeItemsAddAccessMemberEvent(authentication, new ITypeItem[] { this, }, new string[] { memberID, }, new AccessType[] { accessType, });
            }
            catch (Exception e)
            {
                this.CremaHost.Error(e);
                throw;
            }
        }

        public void SetAccessMember(Authentication authentication, string memberID, AccessType accessType)
        {
            try
            {
                this.DataBase.ValidateBeginInDataBase(authentication);
                this.CremaHost.DebugMethod(authentication, this, nameof(SetAccessMember), this, memberID, accessType);
                base.ValidateSetAccessMember(authentication, memberID, accessType);
                this.Sign(authentication);
                this.Context.InvokeTypeItemSetAccessMember(authentication, this, this.AccessInfo, memberID, accessType);
                base.SetAccessMember(authentication, memberID, accessType);
                this.Context.InvokeItemsSetAccessMemberEvent(authentication, new ITypeItem[] { this, }, new string[] { memberID, }, new AccessType[] { accessType, });
            }
            catch (Exception e)
            {
                this.CremaHost.Error(e);
                throw;
            }
        }

        public void RemoveAccessMember(Authentication authentication, string memberID)
        {
            try
            {
                this.DataBase.ValidateBeginInDataBase(authentication);
                this.CremaHost.DebugMethod(authentication, this, nameof(RemoveAccessMember), this, memberID);
                base.ValidateRemoveAccessMember(authentication, memberID);
                this.Sign(authentication);
                this.Context.InvokeTypeItemRemoveAccessMember(authentication, this, this.AccessInfo, memberID);
                base.RemoveAccessMember(authentication, memberID);
                this.Context.InvokeItemsRemoveAccessMemberEvent(authentication, new ITypeItem[] { this, }, new string[] { memberID, });
            }
            catch (Exception e)
            {
                this.CremaHost.Error(e);
                throw;
            }
        }

        public void Lock(Authentication authentication, string comment)
        {
            try
            {
                this.DataBase.ValidateBeginInDataBase(authentication);
                this.CremaHost.DebugMethod(authentication, this, nameof(Lock), this, comment);
                base.ValidateLock(authentication);
                this.Sign(authentication);
                this.Context.InvokeTypeItemLock(authentication, this, comment);
                base.Lock(authentication, comment);
                this.Context.InvokeItemsLockedEvent(authentication, new ITypeItem[] { this, }, new string[] { comment });
            }
            catch (Exception e)
            {
                this.CremaHost.Error(e);
                throw;
            }
        }

        public void Unlock(Authentication authentication)
        {
            try
            {
                this.DataBase.ValidateBeginInDataBase(authentication);
                this.CremaHost.DebugMethod(authentication, this, nameof(Unlock), this);
                base.ValidateUnlock(authentication);
                this.Sign(authentication);
                this.Context.InvokeTypeItemUnlock(authentication, this);
                base.Unlock(authentication);
                this.Context.InvokeItemsUnlockedEvent(authentication, new ITypeItem[] { this, });
            }
            catch (Exception e)
            {
                this.CremaHost.Error(e);
                throw;
            }
        }

        public void Rename(Authentication authentication, string name)
        {
            try
            {
                this.DataBase.ValidateBeginInDataBase(authentication);
                this.CremaHost.DebugMethod(authentication, this, nameof(Rename), this, name);
                base.ValidateRename(authentication, name);
                this.Sign(authentication);
                var items = EnumerableUtility.One(this).ToArray();
                var oldNames = items.Select(item => item.Name).ToArray();
                var oldPaths = items.Select(item => item.Path).ToArray();
                var dataSet = this.ReadAllData(authentication, true);
                this.Container.InvokeCategoryRename(authentication, this, name, dataSet);
                base.Rename(authentication, name);
                this.Container.InvokeCategoriesRenamedEvent(authentication, items, oldNames, oldPaths, dataSet);
            }
            catch (Exception e)
            {
                this.CremaHost.Error(e);
                throw;
            }
        }

        public void Move(Authentication authentication, string parentPath)
        {
            try
            {
                this.DataBase.ValidateBeginInDataBase(authentication);
                this.CremaHost.DebugMethod(authentication, this, nameof(Move), this, parentPath);
                base.ValidateMove(authentication, parentPath);
                this.Sign(authentication);
                var items = EnumerableUtility.One(this).ToArray();
                var oldPaths = items.Select(item => item.Path).ToArray();
                var oldParentPaths = items.Select(item => item.Parent.Path).ToArray();
                var dataSet = this.ReadAllData(authentication, true);
                this.Container.InvokeCategoryMove(authentication, this, parentPath, dataSet);
                base.Move(authentication, parentPath);
                this.Container.InvokeCategoriesMovedEvent(authentication, items, oldPaths, oldParentPaths, dataSet);
            }
            catch (Exception e)
            {
                this.CremaHost.Error(e);
                throw;
            }
        }

        public void Delete(Authentication authentication)
        {
            try
            {
                this.DataBase.ValidateBeginInDataBase(authentication);
                this.CremaHost.DebugMethod(authentication, this, nameof(Delete), this);
                base.ValidateDelete(authentication);
                this.Sign(authentication);
                var items = EnumerableUtility.One(this).ToArray();
                var oldPaths = items.Select(item => item.Path).ToArray();
                var container = this.Container;
                var dataSet = this.ReadAllData(authentication, true);
                container.InvokeCategoryDelete(authentication, this, dataSet);
                base.Delete(authentication);
                container.InvokeCategoriesDeletedEvent(authentication, items, oldPaths, dataSet);
            }
            catch (Exception e)
            {
                this.CremaHost.Error(e);
                throw;
            }
        }

        public TypeCategory AddNewCategory(Authentication authentication, string name)
        {
            try
            {
                this.DataBase.ValidateBeginInDataBase(authentication);
                return this.Container.AddNew(authentication, name, base.Path);
            }
            catch (Exception e)
            {
                this.CremaHost.Error(e);
                throw;
            }
        }

        public NewTypeTemplate NewType(Authentication authentication)
        {
            try
            {
                this.DataBase.ValidateBeginInDataBase(authentication);
                this.CremaHost.DebugMethod(authentication, this, nameof(NewType), this);
                var template = new NewTypeTemplate(this);
                template.BeginEdit(authentication);
                return template;
            }
            catch (Exception e)
            {
                this.CremaHost.Error(e);
                throw;
            }
        }

        public CremaDataSet GetDataSet(Authentication authentication, long revision)
        {
            try
            {
                this.DataBase.ValidateAsyncBeginInDataBase(authentication);
                this.CremaHost.DebugMethod(authentication, this, nameof(GetDataSet), this, revision);
                var info = this.Dispatcher.Invoke(() =>
                {
                    this.ValidateAccessType(authentication, AccessType.Guest);
                    this.Sign(authentication);
                    return new Tuple<string, string>(this.CremaHost.RepositoryPath, this.LocalPath);
                });
                var dataSet = this.Container.Repository.GetTypeCategoryData(info.Item1, info.Item2, revision);
                return dataSet;
            }
            catch (Exception e)
            {
                this.CremaHost.Error(e);
                throw;
            }
        }

        public LogInfo[] GetLog(Authentication authentication)
        {
            try
            {
                this.DataBase.ValidateAsyncBeginInDataBase(authentication);
                this.CremaHost.DebugMethod(authentication, this, nameof(GetLog), this);
                var localPath = this.Dispatcher.Invoke(() =>
                {
                    this.ValidateAccessType(authentication, AccessType.Guest);
                    this.Sign(authentication);
                    return this.LocalPath;
                });
                var result = this.Context.GetCategoryLog(localPath);
                return result;
            }
            catch (Exception e)
            {
                this.CremaHost.Error(e);
                throw;
            }
        }

        public FindResultInfo[] Find(Authentication authentication, string text, FindOptions options)
        {
            try
            {
                this.DataBase.ValidateAsyncBeginInDataBase(authentication);
                this.CremaHost.DebugMethod(authentication, this, nameof(Find), this, text, options);
                var items = this.Dispatcher.Invoke(() =>
                {
                    this.ValidateAccessType(authentication, AccessType.Guest);
                    this.Sign(authentication);
                    var descendants = EnumerableUtility.Descendants<ITypeItem>(this, item => item.Childs);
                    return EnumerableUtility.Friends(this, descendants).Select(item => item.Path).ToArray();
                });
                var service = this.GetService(typeof(DataFindService)) as DataFindService;
                var result = service.Dispatcher.Invoke(() => service.FindFromType(this.DataBase.ID, items, text, options));
                return result;
            }
            catch (Exception e)
            {
                this.CremaHost.Error(e);
                throw;
            }
        }

        public void SetProperty(Authentication authentication, string propertyName, string value)
        {
            try
            {
                this.DataBase.ValidateBeginInDataBase(authentication);
                this.CremaHost.DebugMethod(authentication, this, nameof(SetProperty), this, propertyName, value);
                this.Sign(authentication);
            }
            catch (Exception e)
            {
                this.CremaHost.Error(e);
                throw;
            }
        }

        /// <summary>
        /// 폴더내에 모든 타입과 타입이 사용하고 있는 테이블, 상속된 테이블을 읽어들입니다.
        /// </summary>
        public CremaDataSet ReadAllData(Authentication authentication, bool recursive)
        {
            try
            {
                var dataSet = CremaDataSet.Create(new SignatureDateProvider(authentication.ID));
                var types = CollectTypes();
                var tables = CollectTables();
                var typeFiles = types.Select(item => item.SchemaPath).ToArray();
                var tableFiles = tables.Select(item => item.Parent ?? item)
                                       .Select(item => item.XmlPath)
                                       .Distinct()
                                       .ToArray();
                dataSet.ReadMany(typeFiles, tableFiles);
                dataSet.AcceptChanges();
                return dataSet;

                Type[] CollectTypes()
                {
                    if (recursive == true)
                    {
                        return EnumerableUtility.Descendants<IItem, Type>(this as IItem, item => item.Childs).ToArray();
                    }
                    return this.Types.ToArray();
                }

                Table[] CollectTables()
                {
                    var tableContext = this.GetService(typeof(TableContext)) as TableContext;
                    var query = from table in EnumerableUtility.Descendants<IItem, Table>(tableContext.Root as IItem, item => item.Childs)
                                from type in types
                                where table.IsTypeUsed(type.Path)
                                select table;

                    return query.ToArray();
                }
            }
            catch (Exception e)
            {
                this.CremaHost.Error(e);
                throw;
            }
        }

        /// <summary>
        /// 폴더내의 타입들을 읽어들입니다.
        /// </summary>
        public CremaDataSet ReadData(Authentication authentication)
        {
            try
            {
                return this.ReadData(authentication, false);
            }
            catch (Exception e)
            {
                this.CremaHost.Error(e);
                throw;
            }
        }

        public CremaDataSet ReadData(Authentication authentication, bool recursive)
        {
            try
            {
                var dataSet = CremaDataSet.Create(new SignatureDateProvider(authentication.ID));
                var types = CollectTypes();

                var typeFiles = types.Select(item => item.SchemaPath).ToArray();
                dataSet.ReadMany(typeFiles, new string[] { });
                dataSet.AcceptChanges();
                return dataSet;

                Type[] CollectTypes()
                {
                    if (recursive == true)
                    {
                        return EnumerableUtility.Descendants<IItem, Type>(this as IItem, item => item.Childs).ToArray();
                    }
                    return this.Types.ToArray();
                }
            }
            catch (Exception e)
            {
                this.CremaHost.Error(e);
                throw;
            }
        }

        public object GetService(System.Type serviceType)
        {
            return this.DataBase.GetService(serviceType);
        }

        public string LocalPath
        {
            get { return this.Context.GenerateCategoryPath(base.Path); }
        }

        public CremaHost CremaHost
        {
            get { return this.Context.CremaHost; }
        }

        public DataBase DataBase
        {
            get { return this.Context.DataBase; }
        }

        public CremaDispatcher Dispatcher
        {
            get { return this.Context?.Dispatcher; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnValidateRename(IAuthentication authentication, object target, string oldPath, string newPath)
        {
            base.OnValidateRename(authentication, target, oldPath, newPath);
            if (this.templateList.Any() == true)
                throw new InvalidOperationException(Resources.Exception_CannotRenameOnCreateType);
            this.ValidateUsingTables(authentication);
            var categoryName = new CategoryName(Regex.Replace(this.Path, $"^{oldPath}", newPath));
            this.Context.ValidateCategoryPath(categoryName);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnValidateMove(IAuthentication authentication, object target, string oldPath, string newPath)
        {
            base.OnValidateMove(authentication, target, oldPath, newPath);
            if (this.templateList.Any() == true)
                throw new InvalidOperationException(Resources.Exception_CannotMoveOnCreateType);
            this.ValidateUsingTables(authentication);
            var categoryName = new CategoryName(Regex.Replace(this.Path, $"^{oldPath}", newPath));
            this.Context.ValidateCategoryPath(categoryName);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnValidateDelete(IAuthentication authentication, object target)
        {
            base.OnValidateDelete(authentication, target);
            if (this.templateList.Any() == true)
                throw new InvalidOperationException(Resources.Exception_CannotDeleteOnCreateType);
            var types = EnumerableUtility.Descendants<IItem, Type>(this as IItem, item => item.Childs).ToArray();
            if (types.Any() == true)
                throw new InvalidOperationException(Resources.Exception_CannotDeletePathWithItems);

            this.ValidateUsingTables(authentication);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetAccessInfo(AccessInfo accessInfo)
        {
            accessInfo.Path = this.Path;
            base.AccessInfo = accessInfo;
        }

        public void Attach(NewTypeTemplate template)
        {
            template.EditCanceled += (s, e) => this.templateList.Remove(template);
            template.EditEnded += (s, e) => this.templateList.Remove(template);
            this.templateList.Add(template);
        }

        public new string Name
        {
            get
            {
                this.Dispatcher?.VerifyAccess();
                return base.Name;
            }
        }

        public new string Path
        {
            get
            {
                this.Dispatcher?.VerifyAccess();
                return base.Path;
            }
        }

        public new bool IsLocked
        {
            get
            {
                this.Dispatcher?.VerifyAccess();
                return base.IsLocked;
            }
        }

        public new bool IsPrivate
        {
            get
            {
                this.Dispatcher?.VerifyAccess();
                return base.IsPrivate;
            }
        }

        public long Revision => throw new NotSupportedException();

        public new AccessInfo AccessInfo
        {
            get
            {
                this.Dispatcher?.VerifyAccess();
                return base.AccessInfo;
            }
        }

        public new LockInfo LockInfo
        {
            get
            {
                this.Dispatcher?.VerifyAccess();
                return base.LockInfo;
            }
        }

        public new event EventHandler Renamed
        {
            add
            {
                this.Dispatcher?.VerifyAccess();
                base.Renamed += value;
            }
            remove
            {
                this.Dispatcher?.VerifyAccess();
                base.Renamed -= value;
            }
        }

        public new event EventHandler Moved
        {
            add
            {
                this.Dispatcher?.VerifyAccess();
                base.Moved += value;
            }
            remove
            {
                this.Dispatcher?.VerifyAccess();
                base.Moved -= value;
            }
        }

        public new event EventHandler Deleted
        {
            add
            {
                this.Dispatcher?.VerifyAccess();
                base.Deleted += value;
            }
            remove
            {
                this.Dispatcher?.VerifyAccess();
                base.Deleted -= value;
            }
        }

        public new event EventHandler LockChanged
        {
            add
            {
                this.Dispatcher?.VerifyAccess();
                base.LockChanged += value;
            }
            remove
            {
                this.Dispatcher?.VerifyAccess();
                base.LockChanged -= value;
            }
        }

        public new event EventHandler AccessChanged
        {
            add
            {
                this.Dispatcher?.VerifyAccess();
                base.AccessChanged += value;
            }
            remove
            {
                this.Dispatcher?.VerifyAccess();
                base.AccessChanged -= value;
            }
        }

        private void ValidateUsingTables(IAuthentication authentication)
        {
            var tables = this.GetService(typeof(TableCollection)) as TableCollection;
            var types = EnumerableUtility.Descendants<IItem, Type>(this as IItem, item => item.Childs).ToArray();
            {
                var query = from Table item in tables
                            from type in types
                            where item.IsTypeUsed(type.Path) && item.VerifyAccessType(authentication, AccessType.Master) == false
                            select item;

                if (query.Any() == true)
                    throw new PermissionDeniedException(string.Format(Resources.Exception_ItemsPermissionDenined_Format, string.Format(", ", query)));
            }

            {
                var query = from Table item in tables
                            from type in types
                            where item.IsTypeUsed(type.Path) && item.TableState != TableState.None
                            select item.Name;

                if (query.Any() == true)
                    throw new InvalidOperationException(string.Format(Resources.Exception_TableIsBeingEdited_Format, string.Join(", ", query)));
            }
        }

        private void Sign(Authentication authentication)
        {
            authentication.Sign();
        }

        #region ITypeCategory

        ITypeCategory ITypeCategory.AddNewCategory(Authentication authentication, string name)
        {
            return this.AddNewCategory(authentication, name);
        }

        ITypeTemplate ITypeCategory.NewType(Authentication authentication)
        {
            return this.NewType(authentication);
        }

        ITypeCategory ITypeCategory.Parent
        {
            get
            {
                this.Dispatcher?.VerifyAccess();
                return this.Parent;
            }
        }

        IContainer<ITypeCategory> ITypeCategory.Categories
        {
            get
            {
                this.Dispatcher?.VerifyAccess();
                return this.Categories;
            }
        }

        IContainer<IType> ITypeCategory.Types
        {
            get
            {
                this.Dispatcher?.VerifyAccess();
                return this.Types;
            }
        }

        #endregion

        #region ITypeItem

        ITypeItem ITypeItem.Parent
        {
            get
            {
                this.Dispatcher?.VerifyAccess();
                return this.Parent;
            }
        }

        IEnumerable<ITypeItem> ITypeItem.Childs
        {
            get
            {
                this.Dispatcher?.VerifyAccess();
                foreach (var item in this.Categories)
                {
                    yield return item;
                }

                foreach (var item in this.Items)
                {
                    yield return item;
                }
            }
        }

        #endregion

        #region IServiceProvider

        object IServiceProvider.GetService(System.Type serviceType)
        {
            return (this.DataBase as IDataBase).GetService(serviceType);
        }

        #endregion
    }
}
