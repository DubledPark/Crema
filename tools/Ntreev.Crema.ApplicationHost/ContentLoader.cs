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

using FirstFloor.ModernUI.Windows;
using Ntreev.Crema.Tools.Framework;
using Ntreev.Library.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ntreev.Crema.ApplicationHost
{
    [Export]
    public class ContentLoader : DefaultContentLoader, IContentLoader
    {
        private readonly IContentService contentService;

        [ImportingConstructor]
        public ContentLoader(IContentService contentService)
        {
            this.contentService = contentService;
        }

        protected override object LoadContent(Uri uri)
        {
            var tuple = this.LoadView(uri);

            if (tuple == null)
                return null;

            var view = tuple.Item1;
            var viewModel = tuple.Item2;

            if (viewModel == null)
                return viewModel;

            if (view is DependencyObject)
            {
                Caliburn.Micro.ViewModelBinder.Bind(viewModel, view as DependencyObject, null);
            }

            return view;
        }

        private Tuple<object, object> LoadView(Uri uri)
        {
            if (uri.IsAbsoluteUri == false || uri.Scheme != "vm")
            {
                var view = base.LoadContent(uri);
                var viewModel = Caliburn.Micro.ViewModelLocator.LocateForView(view);
                return new Tuple<object, object>(view, viewModel);
            }

            var hashCode = uri.LocalPath.TrimStart(PathUtility.SeparatorChar);
            var hashValue = int.Parse(hashCode);

            foreach (var item in this.contentService.Contents)
            {
                if (item.GetHashCode() == hashValue)
                {
                    return new Tuple<object, object>(Caliburn.Micro.ViewLocator.LocateForModel(item, null, null), item);
                }
            }
            
            return null;
        }
    }
}
