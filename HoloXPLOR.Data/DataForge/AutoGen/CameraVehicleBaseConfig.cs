using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CameraVehicleBaseConfig")]
    public partial class CameraVehicleBaseConfig
    {
        [XmlElement(ElementName = "rotationInitial")]
        public Ang3 RotationInitial { get; set; }

        [XmlElement(ElementName = "rotationMin")]
        public Ang3 RotationMin { get; set; }

        [XmlElement(ElementName = "rotationMax")]
        public Ang3 RotationMax { get; set; }

        [XmlAttribute(AttributeName = "firstPerson")]
        public Boolean FirstPerson { get; set; }

        [XmlAttribute(AttributeName = "canRotate")]
        public Boolean CanRotate { get; set; }

        [XmlAttribute(AttributeName = "motionBlur")]
        public Boolean MotionBlur { get; set; }

        [XmlAttribute(AttributeName = "availableLanded")]
        public Boolean AvailableLanded { get; set; }

    }
}
