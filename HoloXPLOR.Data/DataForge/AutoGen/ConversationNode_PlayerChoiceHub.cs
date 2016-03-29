using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ConversationNode_PlayerChoiceHub")]
    public partial class ConversationNode_PlayerChoiceHub : ConversationNode_Base
    {
        [XmlAttribute(AttributeName = "targetNPC")]
        public Guid TargetNPC { get; set; }

        [XmlArray(ElementName = "innerVoice")]
        [XmlArrayItem(ElementName = "String", Type=typeof(_String))]
        public _String[] InnerVoice { get; set; }

        [XmlAttribute(AttributeName = "timeOut")]
        public Single TimeOut { get; set; }

        [XmlAttribute(AttributeName = "timeOutLink")]
        public String TimeOutLink { get; set; }

        [XmlArray(ElementName = "outputLinks")]
        [XmlArrayItem(ElementName = "WeakPointer", Type=typeof(_WeakPointer))]
        public _WeakPointer[] OutputLinks { get; set; }

    }
}
