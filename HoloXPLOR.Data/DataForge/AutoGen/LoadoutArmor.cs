using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "LoadoutArmor")]
    public partial class LoadoutArmor
    {
        [XmlAttribute(AttributeName = "armorType")]
        public ArmorType ArmorType { get; set; }

        [XmlAttribute(AttributeName = "starMarineTeam")]
        public StarMarineTeam StarMarineTeam { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "imageName")]
        public String ImageName { get; set; }

        [XmlAttribute(AttributeName = "localizationIdentifier")]
        public String LocalizationIdentifier { get; set; }

        [XmlArray(ElementName = "unlockingBadges")]
        [XmlArrayItem(ElementName = "Enum", Type=typeof(_StarMarineLoadoutBadges))]
        public _StarMarineLoadoutBadges[] UnlockingBadges { get; set; }

        [XmlAttribute(AttributeName = "numSmallSlots")]
        public Int32 NumSmallSlots { get; set; }

        [XmlAttribute(AttributeName = "numMediumSlots")]
        public Int32 NumMediumSlots { get; set; }

        [XmlAttribute(AttributeName = "numLargeSlots")]
        public Int32 NumLargeSlots { get; set; }

        [XmlAttribute(AttributeName = "numGadgetSlots")]
        public Int32 NumGadgetSlots { get; set; }

        [XmlAttribute(AttributeName = "numGrenadeSlots")]
        public Int32 NumGrenadeSlots { get; set; }

        [XmlAttribute(AttributeName = "numMagazines")]
        public Int32 NumMagazines { get; set; }

    }
}
