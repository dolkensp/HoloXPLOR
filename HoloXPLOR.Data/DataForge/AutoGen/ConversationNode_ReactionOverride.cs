using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ConversationNode_ReactionOverride")]
    public partial class ConversationNode_ReactionOverride : ConversationNode_BaseNext
    {
        [XmlAttribute(AttributeName = "character")]
        public Guid Character { get; set; }

        [XmlElement(ElementName = "reaction")]
        public ConversationReaction Reaction { get; set; }

        [XmlAttribute(AttributeName = "enable")]
        public Boolean Enable { get; set; }

    }
}
