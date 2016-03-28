using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "VehicleItemIdentifier")]
    public partial class VehicleItemIdentifier : VehicleItem
    {
        [XmlElement(ElementName = "IdentifierParams")]
        public VehicleItemIdentifierParams IdentifierParams { get; set; }

    }
}
