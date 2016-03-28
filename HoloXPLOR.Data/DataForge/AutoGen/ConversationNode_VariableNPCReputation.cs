using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ConversationNode_VariableNPCReputation")]
    public partial class ConversationNode_VariableNPCReputation : ConversationNode_BaseNext
    {
        [XmlAttribute(AttributeName = "npc")]
        public Guid Npc { get; set; }

        [XmlAttribute(AttributeName = "amount")]
        public Single Amount { get; set; }

    }
}
