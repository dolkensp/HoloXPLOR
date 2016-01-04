using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.XML
{
    public abstract class XmlCollection<T>
    {
        [XmlAttribute(AttributeName = "count")]
        [DefaultValue(0)]
        public Int32 Count
        {
            get { return this.Items == null ? 0 : this.Items.Length; }
            set { /* required for xml serialization */ }
        }

        [XmlIgnore]
        public abstract T[] Items { get; set; }
        [XmlIgnore]
        public T this[Int32 index]
        {
            get { return this.Items[index]; }
            set { this.Items[index] = value; }
        }
    }
}