using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CameraLensStreak")]
    public partial class CameraLensStreak
    {
        [XmlAttribute(AttributeName = "Intensity")]
        public Single Intensity { get; set; }

        [XmlAttribute(AttributeName = "Width")]
        public Single Width { get; set; }

        [XmlElement(ElementName = "Tint")]
        public RGB Tint { get; set; }

    }
}
