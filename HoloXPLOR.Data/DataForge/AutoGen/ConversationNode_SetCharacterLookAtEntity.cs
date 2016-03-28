using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ConversationNode_SetCharacterLookAtEntity")]
    public partial class ConversationNode_SetCharacterLookAtEntity : ConversationNode_BaseNext
    {
        [XmlAttribute(AttributeName = "character")]
        public Guid Character { get; set; }

        [XmlAttribute(AttributeName = "entitySlotToLookAt")]
        public Int32 EntitySlotToLookAt { get; set; }

    }
}
