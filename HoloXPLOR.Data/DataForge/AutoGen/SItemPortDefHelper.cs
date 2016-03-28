using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SItemPortDefHelper")]
    public partial class SItemPortDefHelper
    {
        [XmlAttribute(AttributeName = "Name")]
        public String Name { get; set; }

        [XmlElement(ElementName = "Offset")]
        public QuatT Offset { get; set; }

    }
}
