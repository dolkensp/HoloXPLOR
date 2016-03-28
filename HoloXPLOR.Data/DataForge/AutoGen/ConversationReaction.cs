using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ConversationReaction")]
    public partial class ConversationReaction
    {
        [XmlAttribute(AttributeName = "reactionConversation")]
        public Guid ReactionConversation { get; set; }

        [XmlAttribute(AttributeName = "isReactionInnerBubbleLeft")]
        public Boolean IsReactionInnerBubbleLeft { get; set; }

        [XmlAttribute(AttributeName = "isReactionLookAway")]
        public Boolean IsReactionLookAway { get; set; }

        [XmlAttribute(AttributeName = "isReactionPickupConversation")]
        public Boolean IsReactionPickupConversation { get; set; }

        [XmlAttribute(AttributeName = "isReactionTooAnnoyedToTalk")]
        public Boolean IsReactionTooAnnoyedToTalk { get; set; }

        [XmlAttribute(AttributeName = "reactionAnnoyanceMin")]
        public Single ReactionAnnoyanceMin { get; set; }

        [XmlAttribute(AttributeName = "reactionAnnoyanceMax")]
        public Single ReactionAnnoyanceMax { get; set; }

    }
}
