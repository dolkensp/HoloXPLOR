using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "Collectible")]
    public partial class Collectible
    {
        [XmlAttribute(AttributeName = "type")]
        public Guid Type { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "displayName")]
        public String DisplayName { get; set; }

        [XmlAttribute(AttributeName = "reward")]
        public Int32 Reward { get; set; }

        [XmlAttribute(AttributeName = "journalEntry")]
        public Guid JournalEntry { get; set; }

    }
}
