using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SItemPortCoreParams")]
    public partial class SItemPortCoreParams
    {
        [XmlArray(ElementName = "Ports")]
        [XmlArrayItem(Type = typeof(SItemPortDef))]
        public SItemPortDef[] Ports { get; set; }

        [XmlAttribute(AttributeName = "PortFlags")]
        public String PortFlags { get; set; }

        [XmlAttribute(AttributeName = "PortTags")]
        public String PortTags { get; set; }

        [XmlAttribute(AttributeName = "RequiredItemTags")]
        public String RequiredItemTags { get; set; }

    }
}
