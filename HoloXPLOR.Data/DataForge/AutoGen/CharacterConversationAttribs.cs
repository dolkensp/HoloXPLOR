using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CharacterConversationAttribs")]
    public partial class CharacterConversationAttribs
    {
        [XmlArray(ElementName = "reactions")]
        [XmlArrayItem(Type = typeof(ConversationReaction))]
        public ConversationReaction[] Reactions { get; set; }

        [XmlAttribute(AttributeName = "annoyanceOnLeaving")]
        public Single AnnoyanceOnLeaving { get; set; }

        [XmlAttribute(AttributeName = "annoyanceReductionRate")]
        public Single AnnoyanceReductionRate { get; set; }

    }
}
