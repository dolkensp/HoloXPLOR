using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ChatCommandName")]
    public partial class ChatCommandName
    {
        [XmlAttribute(AttributeName = "commandName")]
        public String CommandName { get; set; }

    }
}
