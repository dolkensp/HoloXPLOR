using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CameraVehicleOrbit")]
    public partial class CameraVehicleOrbit
    {
        [XmlElement(ElementName = "config")]
        public CameraVehicleOrbitConfig Config { get; set; }

    }
}
