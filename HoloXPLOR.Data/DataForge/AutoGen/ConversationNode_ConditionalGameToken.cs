using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ConversationNode_ConditionalGameToken")]
    public partial class ConversationNode_ConditionalGameToken : ConversationNode_BaseNext
    {
        [XmlAttribute(AttributeName = "condition")]
        public String Condition { get; set; }

    }
}
