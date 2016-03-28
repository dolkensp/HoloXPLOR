using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CommunicationChannel")]
    public partial class CommunicationChannel
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "minSilence")]
        public Single MinSilence { get; set; }

        [XmlAttribute(AttributeName = "flushSilence")]
        public Single FlushSilence { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public eCommunicationChannelType Type { get; set; }

        [XmlAttribute(AttributeName = "priority")]
        public Int32 Priority { get; set; }

        [XmlAttribute(AttributeName = "minSpeakerSilence")]
        public Single MinSpeakerSilence { get; set; }

        [XmlAttribute(AttributeName = "ignoreSpeakerSilence")]
        public Boolean IgnoreSpeakerSilence { get; set; }

        [XmlElement(ElementName = "subtitles")]
        public CommunicationSubtitleSettings Subtitles { get; set; }

        [XmlArray(ElementName = "audioRTPC")]
        [XmlArrayItem(Type = typeof(CommunicationAudioRTPC))]
        public CommunicationAudioRTPC[] AudioRTPC { get; set; }

        [XmlArray(ElementName = "subChannels")]
        [XmlArrayItem(Type = typeof(CommunicationChannel))]
        public CommunicationChannel[] SubChannels { get; set; }

    }
}
