using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CameraSpeedParams")]
    public partial class CameraSpeedParams
    {
        [XmlAttribute(AttributeName = "active")]
        public Boolean Active { get; set; }

        [XmlAttribute(AttributeName = "fov")]
        public Single Fov { get; set; }

        [XmlAttribute(AttributeName = "blurAmount")]
        public Single BlurAmount { get; set; }

        [XmlAttribute(AttributeName = "velocityMin")]
        public Single VelocityMin { get; set; }

        [XmlAttribute(AttributeName = "velocityMax")]
        public Single VelocityMax { get; set; }

    }
}
