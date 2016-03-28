using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ChatEmoteData")]
    public partial class ChatEmoteData
    {
        [XmlAttribute(AttributeName = "EmoteType")]
        public String EmoteType { get; set; }

        [XmlAttribute(AttributeName = "Disable")]
        public Boolean Disable { get; set; }

        [XmlAttribute(AttributeName = "isInterruptable")]
        public Boolean IsInterruptable { get; set; }

        [XmlElement(ElementName = "AnimData")]
        public ChatEmoteAnimData AnimData { get; set; }

    }
}
