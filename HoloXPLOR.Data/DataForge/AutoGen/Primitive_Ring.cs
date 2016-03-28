using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "Primitive_Ring")]
    public partial class Primitive_Ring
    {
        [XmlElement(ElementName = "Position")]
        public Vec3 Position { get; set; }

        [XmlElement(ElementName = "Rotation")]
        public Vec3 Rotation { get; set; }

        [XmlAttribute(AttributeName = "InnerRadius")]
        public Single InnerRadius { get; set; }

        [XmlAttribute(AttributeName = "OuterRadius")]
        public Single OuterRadius { get; set; }

        [XmlAttribute(AttributeName = "StartAngle")]
        public Single StartAngle { get; set; }

        [XmlAttribute(AttributeName = "EndAngle")]
        public Single EndAngle { get; set; }

        [XmlElement(ElementName = "UV_Start")]
        public Vec2 UV_Start { get; set; }

        [XmlElement(ElementName = "UV_Size")]
        public Vec2 UV_Size { get; set; }

        [XmlAttribute(AttributeName = "Segments")]
        public UInt32 Segments { get; set; }

    }
}
