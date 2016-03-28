using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CameraShopConfig")]
    public partial class CameraShopConfig
    {
        [XmlElement(ElementName = "initialPositionOffset")]
        public Vec3 InitialPositionOffset { get; set; }

        [XmlAttribute(AttributeName = "minVerticalRotationAngle")]
        public Single MinVerticalRotationAngle { get; set; }

        [XmlAttribute(AttributeName = "maxVerticalRotationAngle")]
        public Single MaxVerticalRotationAngle { get; set; }

        [XmlAttribute(AttributeName = "minHorizontalRotationAngle")]
        public Single MinHorizontalRotationAngle { get; set; }

        [XmlAttribute(AttributeName = "maxHorizontalRotationAngle")]
        public Single MaxHorizontalRotationAngle { get; set; }

        [XmlAttribute(AttributeName = "inTranslationSpeed")]
        public Single InTranslationSpeed { get; set; }

        [XmlAttribute(AttributeName = "outTranslationSpeed")]
        public Single OutTranslationSpeed { get; set; }

        [XmlAttribute(AttributeName = "inRotationSpeed")]
        public Single InRotationSpeed { get; set; }

        [XmlAttribute(AttributeName = "outRotationSpeed")]
        public Single OutRotationSpeed { get; set; }

        [XmlAttribute(AttributeName = "rotationSpeed")]
        public Single RotationSpeed { get; set; }

        [XmlAttribute(AttributeName = "zoomMin")]
        public Single ZoomMin { get; set; }

        [XmlAttribute(AttributeName = "zoomMax")]
        public Single ZoomMax { get; set; }

        [XmlAttribute(AttributeName = "zoomSpeed")]
        public Single ZoomSpeed { get; set; }

    }
}
