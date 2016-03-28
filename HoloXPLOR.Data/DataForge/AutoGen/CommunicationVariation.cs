using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CommunicationVariation")]
    public partial class CommunicationVariation
    {
        [XmlAttribute(AttributeName = "animationName")]
        public String AnimationName { get; set; }

        [XmlAttribute(AttributeName = "soundName")]
        public String SoundName { get; set; }

        [XmlElement(ElementName = "voice")]
        public Dialogue Voice { get; set; }

        [XmlElement(ElementName = "rules")]
        public CommunicationVariationRules Rules { get; set; }

        [XmlElement(ElementName = "conditions")]
        public CommunicationVariationCondition Conditions { get; set; }

    }
}
