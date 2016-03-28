using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ChatFilterOptions")]
    public partial class ChatFilterOptions
    {
        [XmlArray(ElementName = "options")]
        [XmlArrayItem(Type = typeof(ChatFilter))]
        public ChatFilter[] Options { get; set; }

    }
}
