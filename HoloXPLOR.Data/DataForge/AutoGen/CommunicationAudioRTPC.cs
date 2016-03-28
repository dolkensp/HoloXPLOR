using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CommunicationAudioRTPC")]
    public partial class CommunicationAudioRTPC
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public Single Value { get; set; }

    }
}
