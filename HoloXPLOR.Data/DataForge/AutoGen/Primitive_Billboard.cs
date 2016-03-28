using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "Primitive_Billboard")]
    public partial class Primitive_Billboard
    {
        [XmlElement(ElementName = "QuadCentre")]
        public Vec3 QuadCentre { get; set; }

        [XmlElement(ElementName = "QuadSize")]
        public Vec2 QuadSize { get; set; }

        [XmlElement(ElementName = "UV_Start")]
        public Vec2 UV_Start { get; set; }

        [XmlElement(ElementName = "UV_Size")]
        public Vec2 UV_Size { get; set; }

        [XmlElement(ElementName = "ScreenOffset")]
        public Vec2 ScreenOffset { get; set; }

        [XmlAttribute(AttributeName = "InScreenSpace")]
        public Boolean InScreenSpace { get; set; }

    }
}
