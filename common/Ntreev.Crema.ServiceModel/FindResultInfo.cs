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
using Ntreev.Crema.Data.Xml.Schema;
using Ntreev.Library;
using Ntreev.Library.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Ntreev.Crema.ServiceModel
{
    [DataContract(Namespace = SchemaUtility.Namespace)]
    [Serializable]
    public struct FindResultInfo
    {
        [XmlElement]
        public string Path { get; set; }

        [XmlElement]
        public int Row { get; set; }

        [XmlElement]
        public string ColumnName { get; set; }

        [XmlElement]
        public string Value { get; set; }

        [XmlElement]
        public string Tags { get; set; }

        [XmlElement]
        public bool IsEnabled { get; set; }

        [XmlElement]
        public SignatureDate ModificationInfo { get; set; }

        internal static FindResultInfo FromDataRow(CremaDataRow dataRow, CremaDataColumn dataColumn, int index)
        {
            CremaDataTable table = dataRow.Table;
            FindResultInfo fri = new FindResultInfo()
            {
                Path = table.CategoryPath + table.Name,
                Row = index,
                ColumnName = dataColumn.ColumnName,
                Value = dataRow[dataColumn].ToString(),
                Tags = dataRow.DerivedTags.ToString(),
                IsEnabled = dataRow.IsEnabled,
                ModificationInfo = dataRow.ModificationInfo,
            };

            return fri;
        }

        #region DataMember

        [DataMember]
        [XmlIgnore]
        private string Xml
        {
            get { return XmlSerializerUtility.GetString(this); }
            set { this = XmlSerializerUtility.ReadString(this, value); }
        }

        #endregion
    }
}
