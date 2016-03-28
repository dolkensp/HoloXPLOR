using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "LoadoutItem")]
    public partial class LoadoutItem
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "imageName")]
        public String ImageName { get; set; }

        [XmlArray(ElementName = "validArmorTypes")]
        [XmlArrayItem(Type = typeof(BTInputVec3))]
        [XmlArrayItem(Type = typeof(BTInputVec3Var))]
        [XmlArrayItem(Type = typeof(BTInputVec3BB))]
        public ArmorType[] ValidArmorTypes { get; set; }

        [XmlArray(ElementName = "validSlotTypes")]
        [XmlArrayItem(Type = typeof(BTInputVec3Var))]
        public SlotType[] ValidSlotTypes { get; set; }

        [XmlArray(ElementName = "requiredSlotTypes")]
        [XmlArrayItem(Type = typeof(BTInputVec3Var))]
        public SlotType[] RequiredSlotTypes { get; set; }

        [XmlArray(ElementName = "unlockingBadges")]
        [XmlArrayItem(Type = typeof(BTInputVec3BB))]
        public StarMarineLoadoutBadges[] UnlockingBadges { get; set; }

        [XmlAttribute(AttributeName = "magazineName")]
        public String MagazineName { get; set; }

        [XmlArray(ElementName = "attachments")]
        [XmlArrayItem(Type = typeof(LoadoutAttachment))]
        public LoadoutAttachment[] Attachments { get; set; }

        [XmlAttribute(AttributeName = "canItemBeDuplicated")]
        public Boolean CanItemBeDuplicated { get; set; }

    }
}
