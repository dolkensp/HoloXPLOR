using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CommunicationRequest")]
    public partial class CommunicationRequest
    {
        [XmlAttribute(AttributeName = "communication")]
        public String Communication { get; set; }

        [XmlAttribute(AttributeName = "channelName")]
        public String ChannelName { get; set; }

    }
}
