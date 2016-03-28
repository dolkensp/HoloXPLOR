using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ConversationNode_Dialogue")]
    public partial class ConversationNode_Dialogue : ConversationNode_BaseNext
    {
        [XmlElement(ElementName = "dialogue")]
        public Dialogue Dialogue { get; set; }

        [XmlAttribute(AttributeName = "skipNodeInXSecs")]
        public Single SkipNodeInXSecs { get; set; }

    }
}
