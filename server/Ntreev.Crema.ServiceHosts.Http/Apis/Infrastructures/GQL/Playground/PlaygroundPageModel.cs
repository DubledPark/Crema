﻿using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Ntreev.Crema.ServiceHosts.Http.Apis.Infrastructures.GQL.Playground
{
    // https://docs.microsoft.com/en-us/aspnet/core/mvc/razor-pages/?tabs=netcore-cli
    internal class PlaygroundPageModel
    {
        private string _playgroundCSHtml;

        private readonly GraphQLPlaygroundOptions _options;

        public PlaygroundPageModel(GraphQLPlaygroundOptions options)
        {
            _options = options;
        }

        public string Render()
        {
            if (_playgroundCSHtml == null)
            {
                using (var manifestResourceStream = typeof(PlaygroundPageModel).Assembly.GetManifestResourceStream("Ntreev.Crema.ServiceHosts.Http.Apis.Infrastructures.GQL.Playground.playground.cshtml"))
                {
                    using (var streamReader = new StreamReader(manifestResourceStream))
                    {
                        var builder = new StringBuilder(streamReader.ReadToEnd());

                        builder.Replace("@Model.GraphQLEndPoint", _options.GraphQLEndPoint.Value);
                        builder.Replace("@Model.GraphQLConfig", JsonConvert.SerializeObject(_options.GraphQLConfig));
                        builder.Replace("@Model.PlaygroundSettings", JsonConvert.SerializeObject(_options.PlaygroundSettings));

                        _playgroundCSHtml = builder.ToString();
                    }
                }
            }

            return _playgroundCSHtml;
        }
    }
}