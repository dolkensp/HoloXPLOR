using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "Character")]
    public partial class Character
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlElement(ElementName = "conversationAttribs")]
        public CharacterConversationAttribs ConversationAttribs { get; set; }

    }
}
