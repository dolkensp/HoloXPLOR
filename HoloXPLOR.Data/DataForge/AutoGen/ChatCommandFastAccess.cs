using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ChatCommandFastAccess")]
    public partial class ChatCommandFastAccess
    {
        [XmlArray(ElementName = "commands")]
        [XmlArrayItem(Type = typeof(ChatCommandName))]
        public ChatCommandName[] Commands { get; set; }

    }
}
