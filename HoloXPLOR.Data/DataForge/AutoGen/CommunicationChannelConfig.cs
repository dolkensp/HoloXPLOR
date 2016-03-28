using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CommunicationChannelConfig")]
    public partial class CommunicationChannelConfig
    {
        [XmlAttribute(AttributeName = "ChannelConfigName")]
        public String ChannelConfigName { get; set; }

        [XmlArray(ElementName = "Channels")]
        [XmlArrayItem(Type = typeof(CommunicationChannel))]
        public CommunicationChannel[] Channels { get; set; }

    }
}
