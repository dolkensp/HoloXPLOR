using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ConversationNode_BaseNext")]
    public partial class ConversationNode_BaseNext : ConversationNode_Base
    {
        [XmlAttribute(AttributeName = "next")]
        public String Next { get; set; }

    }
}
