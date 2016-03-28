using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "Visor_Curvature")]
    public partial class Visor_Curvature
    {
        [XmlAttribute(AttributeName = "HorizontalFOV")]
        public Single HorizontalFOV { get; set; }

        [XmlAttribute(AttributeName = "VerticalFOV")]
        public Single VerticalFOV { get; set; }

        [XmlAttribute(AttributeName = "ProjectDistance")]
        public Single ProjectDistance { get; set; }

        [XmlElement(ElementName = "Scale")]
        public Vec2 Scale { get; set; }

    }
}
