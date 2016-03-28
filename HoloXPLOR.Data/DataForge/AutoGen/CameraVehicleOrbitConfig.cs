using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CameraVehicleOrbitConfig")]
    public partial class CameraVehicleOrbitConfig : CameraVehicleBaseConfig
    {
        [XmlAttribute(AttributeName = "viewDistanceOverride")]
        public Single ViewDistanceOverride { get; set; }

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
