using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "JournalEntryType")]
    public partial class JournalEntryType
    {
        [XmlAttribute(AttributeName = "DisplayName")]
        public String DisplayName { get; set; }

        [XmlAttribute(AttributeName = "IconName")]
        public String IconName { get; set; }

    }
}
