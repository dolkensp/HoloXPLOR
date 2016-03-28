using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CommunicationConfig")]
    public partial class CommunicationConfig
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlArray(ElementName = "communications")]
        [XmlArrayItem(Type = typeof(CommunicationEntry))]
        public CommunicationEntry[] Communications { get; set; }

    }
}
