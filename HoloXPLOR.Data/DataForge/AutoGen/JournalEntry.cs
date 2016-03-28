using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "JournalEntry")]
    public partial class JournalEntry
    {
        [XmlAttribute(AttributeName = "Title")]
        public String Title { get; set; }

        [XmlAttribute(AttributeName = "SubHeading")]
        public String SubHeading { get; set; }

        [XmlAttribute(AttributeName = "Style")]
        public Guid Style { get; set; }

        [XmlArray(ElementName = "type")]
        [XmlArrayItem(Type = typeof(BaseJournalEntry))]
        [XmlArrayItem(Type = typeof(JournalEntryText))]
        [XmlArrayItem(Type = typeof(JournalEntryAudioLog))]
        public BaseJournalEntry[] Type { get; set; }

    }
}
