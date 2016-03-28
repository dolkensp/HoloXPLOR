using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "VehicleRepairBeam")]
    public partial class VehicleRepairBeam : VehicleItem
    {
        [XmlAttribute(AttributeName = "SparkMaterial")]
        public String SparkMaterial { get; set; }

    }
}
