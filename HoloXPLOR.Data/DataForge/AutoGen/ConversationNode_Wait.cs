using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ConversationNode_Wait")]
    public partial class ConversationNode_Wait : ConversationNode_BaseNext
    {
        [XmlAttribute(AttributeName = "waitTime")]
        public Single WaitTime { get; set; }

    }
}
