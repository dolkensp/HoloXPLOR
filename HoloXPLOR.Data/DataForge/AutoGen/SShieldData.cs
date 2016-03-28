using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SShieldData")]
    public partial class SShieldData
    {
        [XmlAttribute(AttributeName = "FaceType")]
        public EFaceType FaceType { get; set; }

        [XmlAttribute(AttributeName = "MaintenanceRatio")]
        public Single MaintenanceRatio { get; set; }

    }
}
