using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CommunicationName")]
    public partial class CommunicationName
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

    }
}
