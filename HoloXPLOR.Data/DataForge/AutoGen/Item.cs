using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "Item")]
    public partial class Item
    {
        [XmlArray(ElementName = "type")]
        [XmlArrayItem(Type = typeof(BaseItem))]
        [XmlArrayItem(Type = typeof(VehicleItem))]
        [XmlArrayItem(Type = typeof(VehicleItemIdentifier))]
        [XmlArrayItem(Type = typeof(VehicleItemInteriorController))]
        [XmlArrayItem(Type = typeof(VehicleRepairBeam))]
        [XmlArrayItem(Type = typeof(StaticEnvironmentItem))]
        [XmlArrayItem(Type = typeof(HoloTable))]
        [XmlArrayItem(Type = typeof(LoadoutSelector))]
        [XmlArrayItem(Type = typeof(Weapon))]
        public BaseItem[] Type { get; set; }

    }
}
