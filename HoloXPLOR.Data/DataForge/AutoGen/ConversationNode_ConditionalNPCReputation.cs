using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ConversationNode_ConditionalNPCReputation")]
    public partial class ConversationNode_ConditionalNPCReputation : ConversationNode_BaseNext
    {
        [XmlAttribute(AttributeName = "npc")]
        public Guid Npc { get; set; }

        [XmlAttribute(AttributeName = "reputation")]
        public EReputation Reputation { get; set; }

    }
}
