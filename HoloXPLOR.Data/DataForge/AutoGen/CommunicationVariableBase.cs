using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CommunicationVariableBase")]
    public partial class CommunicationVariableBase
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "global")]
        public Boolean Global { get; set; }

    }
}
