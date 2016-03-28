using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SItemPortDefHelperNode")]
    public partial class SItemPortDefHelperNode
    {
        [XmlAttribute(AttributeName = "Tags")]
        public String Tags { get; set; }

        [XmlElement(ElementName = "Helper")]
        public SItemPortDefHelper Helper { get; set; }

        [XmlArray(ElementName = "SubHelpers")]
        [XmlArrayItem(Type = typeof(SItemPortDefHelperNode))]
        public SItemPortDefHelperNode[] SubHelpers { get; set; }

    }
}
