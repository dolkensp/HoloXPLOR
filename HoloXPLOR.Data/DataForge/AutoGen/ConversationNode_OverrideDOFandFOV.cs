using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ConversationNode_OverrideDOFandFOV")]
    public partial class ConversationNode_OverrideDOFandFOV : ConversationNode_BaseNext
    {
        [XmlAttribute(AttributeName = "overrideFOV")]
        public Single OverrideFOV { get; set; }

        [XmlAttribute(AttributeName = "overrideDOF")]
        public Single OverrideDOF { get; set; }

    }
}
