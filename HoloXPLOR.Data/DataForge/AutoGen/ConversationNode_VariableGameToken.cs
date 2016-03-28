using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ConversationNode_VariableGameToken")]
    public partial class ConversationNode_VariableGameToken : ConversationNode_BaseNext
    {
        [XmlAttribute(AttributeName = "setVariable")]
        public String SetVariable { get; set; }

    }
}
