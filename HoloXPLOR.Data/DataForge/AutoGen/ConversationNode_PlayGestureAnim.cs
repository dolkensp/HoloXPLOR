using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ConversationNode_PlayGestureAnim")]
    public partial class ConversationNode_PlayGestureAnim : ConversationNode_BaseNext
    {
        [XmlAttribute(AttributeName = "character")]
        public Guid Character { get; set; }

        [XmlAttribute(AttributeName = "animation")]
        public EGestureAnim Animation { get; set; }

        [XmlAttribute(AttributeName = "forceFinishPrevious")]
        public Boolean ForceFinishPrevious { get; set; }

        [XmlAttribute(AttributeName = "waitForEventToProgress")]
        public Boolean WaitForEventToProgress { get; set; }

    }
}
