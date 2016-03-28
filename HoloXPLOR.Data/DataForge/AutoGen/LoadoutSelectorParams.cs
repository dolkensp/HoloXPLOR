using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "LoadoutSelectorParams")]
    public partial class LoadoutSelectorParams
    {
        [XmlAttribute(AttributeName = "LoadoutSelectorGeometry")]
        public String LoadoutSelectorGeometry { get; set; }

        [XmlAttribute(AttributeName = "Helper")]
        public String Helper { get; set; }

    }
}
