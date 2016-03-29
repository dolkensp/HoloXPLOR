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
        [XmlArrayItem(ElementName = "Enum", Type=typeof(_ArmorType))]
        public _ArmorType[] ValidArmorTypes { get; set; }

        [XmlArray(ElementName = "validSlotTypes")]
        [XmlArrayItem(ElementName = "Enum", Type=typeof(_SlotType))]
        public _SlotType[] ValidSlotTypes { get; set; }

        [XmlArray(ElementName = "requiredSlotTypes")]
        [XmlArrayItem(ElementName = "Enum", Type=typeof(_SlotType))]
        public _SlotType[] RequiredSlotTypes { get; set; }

        [XmlArray(ElementName = "unlockingBadges")]
        [XmlArrayItem(ElementName = "Enum", Type=typeof(_StarMarineLoadoutBadges))]
        public _StarMarineLoadoutBadges[] UnlockingBadges { get; set; }

        [XmlAttribute(AttributeName = "magazineName")]
        public String MagazineName { get; set; }

        [XmlArray(ElementName = "attachments")]
        [XmlArrayItem(Type = typeof(LoadoutAttachment))]
        public LoadoutAttachment[] Attachments { get; set; }

        [XmlAttribute(AttributeName = "canItemBeDuplicated")]
        public Boolean CanItemBeDuplicated { get; set; }

    }
}
