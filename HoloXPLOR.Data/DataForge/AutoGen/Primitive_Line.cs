using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "Primitive_Line")]
    public partial class Primitive_Line
    {
        [XmlElement(ElementName = "LineStart")]
        public Vec3 LineStart { get; set; }

        [XmlElement(ElementName = "LineEnd")]
        public Vec3 LineEnd { get; set; }

        [XmlAttribute(AttributeName = "LineThickness")]
        public Single LineThickness { get; set; }

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
