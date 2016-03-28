using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CameraLensGhostSet")]
    public partial class CameraLensGhostSet
    {
        [XmlAttribute(AttributeName = "SetName")]
        public String SetName { get; set; }

        [XmlAttribute(AttributeName = "Radius")]
        public Single Radius { get; set; }

        [XmlArray(ElementName = "Distortion")]
        [XmlArrayItem(Type = typeof(CameraLensDistortion))]
        public CameraLensDistortion[] Distortion { get; set; }

        [XmlArray(ElementName = "ChromaticAberration")]
        [XmlArrayItem(Type = typeof(CameraLensChromaticAberration))]
        public CameraLensChromaticAberration[] ChromaticAberration { get; set; }

        [XmlArray(ElementName = "Instances")]
        [XmlArrayItem(Type = typeof(CameraLensGhostInstance))]
        public CameraLensGhostInstance[] Instances { get; set; }

    }
}
