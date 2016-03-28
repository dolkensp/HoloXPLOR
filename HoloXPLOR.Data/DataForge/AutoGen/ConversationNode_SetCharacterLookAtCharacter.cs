using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ConversationNode_SetCharacterLookAtCharacter")]
    public partial class ConversationNode_SetCharacterLookAtCharacter : ConversationNode_BaseNext
    {
        [XmlAttribute(AttributeName = "character")]
        public Guid Character { get; set; }

        [XmlAttribute(AttributeName = "characterToLookAt")]
        public Guid CharacterToLookAt { get; set; }

    }
}
