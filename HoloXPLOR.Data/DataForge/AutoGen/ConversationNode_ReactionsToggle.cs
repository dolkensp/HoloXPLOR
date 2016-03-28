using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ConversationNode_ReactionsToggle")]
    public partial class ConversationNode_ReactionsToggle : ConversationNode_BaseNext
    {
        [XmlAttribute(AttributeName = "toggleReactions")]
        public Int32 ToggleReactions { get; set; }

    }
}
