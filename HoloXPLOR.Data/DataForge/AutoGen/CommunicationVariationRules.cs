using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CommunicationVariationRules")]
    public partial class CommunicationVariationRules
    {
        [XmlAttribute(AttributeName = "timeout")]
        public Single Timeout { get; set; }

        [XmlAttribute(AttributeName = "lookAtTarget")]
        public Boolean LookAtTarget { get; set; }

        [XmlAttribute(AttributeName = "finishAnimation")]
        public Boolean FinishAnimation { get; set; }

        [XmlAttribute(AttributeName = "finishSound")]
        public Boolean FinishSound { get; set; }

        [XmlAttribute(AttributeName = "finishVoice")]
        public Boolean FinishVoice { get; set; }

        [XmlAttribute(AttributeName = "finishTimeout")]
        public Boolean FinishTimeout { get; set; }

        [XmlAttribute(AttributeName = "blockMovement")]
        public Boolean BlockMovement { get; set; }

        [XmlAttribute(AttributeName = "blockFire")]
        public Boolean BlockFire { get; set; }

        [XmlAttribute(AttributeName = "animationMethodAction")]
        public Boolean AnimationMethodAction { get; set; }

    }
}
