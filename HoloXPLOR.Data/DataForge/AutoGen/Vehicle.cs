using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "Vehicle")]
    public partial class Vehicle
    {
        [XmlAttribute(AttributeName = "ClassName")]
        public String ClassName { get; set; }

        [XmlElement(ElementName = "GameTokenList")]
        public GameTokens GameTokenList { get; set; }

    }
}
