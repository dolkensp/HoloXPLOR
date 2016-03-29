using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ConversationNode_Hub")]
    public partial class ConversationNode_Hub : ConversationNode_Base
    {
        [XmlAttribute(AttributeName = "linkType")]
        public EConversationHubLinkType LinkType { get; set; }

        [XmlArray(ElementName = "outputLinks")]
        [XmlArrayItem(ElementName = "WeakPointer", Type=typeof(_WeakPointer))]
        public _WeakPointer[] OutputLinks { get; set; }

    }
}
