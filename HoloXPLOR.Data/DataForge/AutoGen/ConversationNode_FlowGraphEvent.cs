using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ConversationNode_FlowGraphEvent")]
    public partial class ConversationNode_FlowGraphEvent : ConversationNode_BaseNext
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public String Value { get; set; }

        [XmlAttribute(AttributeName = "waitForDone")]
        public Boolean WaitForDone { get; set; }

    }
}
