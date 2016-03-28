using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CameraLensGhostInstance")]
    public partial class CameraLensGhostInstance
    {
        [XmlAttribute(AttributeName = "Name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "Position")]
        public Single Position { get; set; }

        [XmlAttribute(AttributeName = "Intensity")]
        public Single Intensity { get; set; }

        [XmlElement(ElementName = "Tint")]
        public RGB Tint { get; set; }

    }
}
