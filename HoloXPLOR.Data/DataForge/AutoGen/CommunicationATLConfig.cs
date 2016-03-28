using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CommunicationATLConfig")]
    public partial class CommunicationATLConfig
    {
        [XmlAttribute(AttributeName = "playTriggerPrefix")]
        public String PlayTriggerPrefix { get; set; }

        [XmlAttribute(AttributeName = "stopTriggerPrefix")]
        public String StopTriggerPrefix { get; set; }

        [XmlAttribute(AttributeName = "speakerVoiceSwitch")]
        public String SpeakerVoiceSwitch { get; set; }

        [XmlAttribute(AttributeName = "speakerTypeSwitch")]
        public String SpeakerTypeSwitch { get; set; }

    }
}
