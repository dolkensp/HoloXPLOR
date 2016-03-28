using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ConversationNode_VariablePlayerReputation")]
    public partial class ConversationNode_VariablePlayerReputation : ConversationNode_BaseNext
    {
        [XmlAttribute(AttributeName = "type")]
        public EReputationType Type { get; set; }

        [XmlAttribute(AttributeName = "amount")]
        public Single Amount { get; set; }

    }
}
