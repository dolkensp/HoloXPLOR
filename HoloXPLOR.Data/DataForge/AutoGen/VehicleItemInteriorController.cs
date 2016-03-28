using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "VehicleItemInteriorController")]
    public partial class VehicleItemInteriorController : VehicleItem
    {
        [XmlElement(ElementName = "GameTokenList")]
        public GameTokens GameTokenList { get; set; }

    }
}
