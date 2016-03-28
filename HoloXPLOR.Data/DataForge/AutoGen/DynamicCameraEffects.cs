using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "DynamicCameraEffects")]
    public partial class DynamicCameraEffects
    {
        [XmlAttribute(AttributeName = "context")]
        public EDynamicCameraEffectsContext Context { get; set; }

        [XmlAttribute(AttributeName = "subContext")]
        public EDynamicCameraEffectsSubContext SubContext { get; set; }

        [XmlElement(ElementName = "cameraParams")]
        public CameraParams CameraParams { get; set; }

        [XmlElement(ElementName = "cameraSpeedParams")]
        public CameraSpeedParams CameraSpeedParams { get; set; }

    }
}
