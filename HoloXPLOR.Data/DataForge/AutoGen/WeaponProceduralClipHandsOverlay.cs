using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "WeaponProceduralClipHandsOverlay")]
    public partial class WeaponProceduralClipHandsOverlay : WeaponProceduralClipBase
    {
        [XmlAttribute(AttributeName = "amplitude")]
        public Single Amplitude { get; set; }

        [XmlAttribute(AttributeName = "amplitudeNoiseFactor")]
        public Single AmplitudeNoiseFactor { get; set; }

        [XmlAttribute(AttributeName = "frequency")]
        public Single Frequency { get; set; }

        [XmlAttribute(AttributeName = "frequencyNoiseFactor")]
        public Single FrequencyNoiseFactor { get; set; }

        [XmlAttribute(AttributeName = "maxDistance")]
        public Single MaxDistance { get; set; }

        [XmlAttribute(AttributeName = "smoothFactor")]
        public Single SmoothFactor { get; set; }

        [XmlAttribute(AttributeName = "phase")]
        public Single Phase { get; set; }

        [XmlElement(ElementName = "rotation")]
        public Vec3 Rotation { get; set; }

        [XmlAttribute(AttributeName = "rotationNoise")]
        public Single RotationNoise { get; set; }

    }
}
