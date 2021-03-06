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

using System.ComponentModel.Composition;
using Ntreev.Crema.Client.Framework;
using Ntreev.Crema.ServiceModel;
using Ntreev.ModernUI.Framework;
using System.ComponentModel;
using Ntreev.Crema.Data;
using Ntreev.Crema.Client.Tables.Properties;

namespace Ntreev.Crema.Client.Tables.PropertyItems.ViewModels
{
    [Export(typeof(IPropertyItem))]
    [RequiredAuthority(Authority.Guest)]
    [ParentType(typeof(PropertyService))]
    public class TableInfoViewModel : PropertyItemBase
    {
        private TableInfo tableInfo;
        private TableDetailInfo tableDetailInfo;
        private ITableDescriptor descriptor;

        public TableInfoViewModel()
        {
            this.DisplayName = Resources.Title_TableInfo;
        }

        public TableInfo TableInfo
        {
            get { return this.tableInfo; }
            set
            {
                this.tableInfo = value;
                this.NotifyOfPropertyChange(nameof(this.TableInfo));
            }
        }

        public TableDetailInfo TableDetailInfo
        {
            get { return this.tableDetailInfo; }
            set
            {
                this.tableDetailInfo = value;
                this.NotifyOfPropertyChange(nameof(this.TableDetailInfo));
            }
        }

        public override bool IsVisible
        {
            get { return this.descriptor != null; }
        }

        public override object SelectedObject
        {
            get { return this.descriptor; }
        }

        public override bool CanSupport(object obj)
        {
            return obj is ITableDescriptor;
        }

        public override void SelectObject(object obj)
        {
            this.Detach();
            this.descriptor = obj as ITableDescriptor;
            this.Attach();
        }

        private void Descriptor_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ITableDescriptor.TableInfo) || e.PropertyName == string.Empty)
            {
                this.TableInfo = this.descriptor.TableInfo;
                this.TableDetailInfo = this.descriptor.TableDetailInfo;
                this.NotifyOfPropertyChange(nameof(this.IsVisible));
            } else if (e.PropertyName == nameof(ITableDescriptor.TableDetailInfo))
            {
                this.TableDetailInfo = this.descriptor.TableDetailInfo;
            }
        }

        private void Attach()
        {
            if (this.descriptor != null)
            {
                if (this.descriptor is INotifyPropertyChanged)
                {
                    (this.descriptor as INotifyPropertyChanged).PropertyChanged += Descriptor_PropertyChanged;
                }
                this.TableInfo = this.descriptor.TableInfo;
                this.TableDetailInfo = this.descriptor.Target.TableDetailInfo;
            }

            this.NotifyOfPropertyChange(nameof(this.IsVisible));
            this.NotifyOfPropertyChange(nameof(this.SelectedObject));
        }

        private void Detach()
        {
            if (this.descriptor != null)
            {
                if (this.descriptor is INotifyPropertyChanged)
                {
                    (this.descriptor as INotifyPropertyChanged).PropertyChanged -= Descriptor_PropertyChanged;
                }
            }
        }
    }
}
