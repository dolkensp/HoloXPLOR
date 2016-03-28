using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "Primitive_Quad")]
    public partial class Primitive_Quad
    {
        [XmlElement(ElementName = "Centre")]
        public Vec3 Centre { get; set; }

        [XmlElement(ElementName = "Size")]
        public Vec2 Size { get; set; }

        [XmlElement(ElementName = "Rotation")]
        public Vec3 Rotation { get; set; }

        [XmlElement(ElementName = "UV_Start")]
        public Vec2 UV_Start { get; set; }

        [XmlElement(ElementName = "UV_Size")]
        public Vec2 UV_Size { get; set; }

    }
}
