using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ARManufacturerData")]
    public partial class ARManufacturerData
    {
        [XmlAttribute(AttributeName = "manufacturerName")]
        public String ManufacturerName { get; set; }

        [XmlAttribute(AttributeName = "manufacturerLogoPath")]
        public String ManufacturerLogoPath { get; set; }

    }
}
