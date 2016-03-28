using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "PurchasableDisplayClothing")]
    public partial class PurchasableDisplayClothing : PurchasableDisplayBase
    {
        [XmlAttribute(AttributeName = "FashionType")]
        public String FashionType { get; set; }

        [XmlAttribute(AttributeName = "FabricMaterial")]
        public String FabricMaterial { get; set; }

        [XmlAttribute(AttributeName = "Style")]
        public String Style { get; set; }

        [XmlAttribute(AttributeName = "Gender")]
        public String Gender { get; set; }

        [XmlAttribute(AttributeName = "Color")]
        public String Color { get; set; }

    }
}
