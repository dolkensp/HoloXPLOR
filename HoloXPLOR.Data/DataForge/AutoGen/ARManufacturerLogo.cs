using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ARManufacturerLogo")]
    public partial class ARManufacturerLogo
    {
        [XmlArray(ElementName = "manufacturerLogoList")]
        [XmlArrayItem(Type = typeof(ARManufacturerData))]
        public ARManufacturerData[] ManufacturerLogoList { get; set; }

    }
}
