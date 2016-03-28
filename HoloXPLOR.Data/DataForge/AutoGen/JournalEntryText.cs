using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "JournalEntryText")]
    public partial class JournalEntryText : BaseJournalEntry
    {
        [XmlAttribute(AttributeName = "BodyText")]
        public String BodyText { get; set; }

    }
}
