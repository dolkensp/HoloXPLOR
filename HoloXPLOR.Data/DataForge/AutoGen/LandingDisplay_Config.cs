using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "LandingDisplay_Config")]
    public partial class LandingDisplay_Config
    {
        [XmlAttribute(AttributeName = "YawPaletteEntry")]
        public HUDPalleteEntry YawPaletteEntry { get; set; }

        [XmlElement(ElementName = "YawPrimitive")]
        public Primitive_Ring YawPrimitive { get; set; }

        [XmlAttribute(AttributeName = "AltitudePaletteEntry")]
        public HUDPalleteEntry AltitudePaletteEntry { get; set; }

        [XmlElement(ElementName = "AltitudePrimitive")]
        public Primitive_Quad AltitudePrimitive { get; set; }

        [XmlAttribute(AttributeName = "AreaRadius")]
        public Single AreaRadius { get; set; }

        [XmlAttribute(AttributeName = "ShipSize")]
        public Single ShipSize { get; set; }

    }
}
