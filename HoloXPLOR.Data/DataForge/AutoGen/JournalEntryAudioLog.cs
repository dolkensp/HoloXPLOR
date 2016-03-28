using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "JournalEntryAudioLog")]
    public partial class JournalEntryAudioLog : BaseJournalEntry
    {
        [XmlAttribute(AttributeName = "AudioLogName")]
        public String AudioLogName { get; set; }

        [XmlAttribute(AttributeName = "Description")]
        public String Description { get; set; }

        [XmlAttribute(AttributeName = "Transcript")]
        public String Transcript { get; set; }

    }
}
