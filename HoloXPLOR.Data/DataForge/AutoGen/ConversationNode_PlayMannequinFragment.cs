using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ConversationNode_PlayMannequinFragment")]
    public partial class ConversationNode_PlayMannequinFragment : ConversationNode_BaseNext
    {
        [XmlAttribute(AttributeName = "character")]
        public Guid Character { get; set; }

        [XmlAttribute(AttributeName = "fragmentID")]
        public EConversationFragmentID FragmentID { get; set; }

        [XmlArray(ElementName = "tags")]
        [XmlArrayItem(ElementName = "String", Type=typeof(_String))]
        public _String[] Tags { get; set; }

        [XmlAttribute(AttributeName = "forceFinishPrevious")]
        public Boolean ForceFinishPrevious { get; set; }

        [XmlAttribute(AttributeName = "waitForEventToProgress")]
        public Boolean WaitForEventToProgress { get; set; }

    }
}
