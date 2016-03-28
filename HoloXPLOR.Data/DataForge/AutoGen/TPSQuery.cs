using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "TPSQuery")]
    public partial class TPSQuery
    {
        [XmlAttribute(AttributeName = "Name")]
        public String Name { get; set; }

        [XmlArray(ElementName = "Options")]
        [XmlArrayItem(Type = typeof(TPSOption))]
        public TPSOption[] Options { get; set; }

    }
}
