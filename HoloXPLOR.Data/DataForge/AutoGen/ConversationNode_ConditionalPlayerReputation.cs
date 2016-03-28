using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ConversationNode_ConditionalPlayerReputation")]
    public partial class ConversationNode_ConditionalPlayerReputation : ConversationNode_BaseNext
    {
        [XmlAttribute(AttributeName = "type")]
        public EReputationType Type { get; set; }

        [XmlAttribute(AttributeName = "reputation")]
        public EReputation Reputation { get; set; }

    }
}
