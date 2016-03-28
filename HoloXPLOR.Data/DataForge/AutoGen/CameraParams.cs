using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CameraParams")]
    public partial class CameraParams
    {
        [XmlAttribute(AttributeName = "fov")]
        public Single Fov { get; set; }

        [XmlAttribute(AttributeName = "focusRange")]
        public Single FocusRange { get; set; }

        [XmlAttribute(AttributeName = "focusMin")]
        public Single FocusMin { get; set; }

        [XmlAttribute(AttributeName = "focusMinScale")]
        public Single FocusMinScale { get; set; }

        [XmlAttribute(AttributeName = "focusMode")]
        public EDynamicCameraEffectsFocusMode FocusMode { get; set; }

        [XmlAttribute(AttributeName = "blurAmount")]
        public Single BlurAmount { get; set; }

        [XmlAttribute(AttributeName = "lerpToSpeed")]
        public Single LerpToSpeed { get; set; }

    }
}
