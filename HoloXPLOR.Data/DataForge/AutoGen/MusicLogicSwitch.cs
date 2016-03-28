using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "MusicLogicSwitch")]
    public partial class MusicLogicSwitch : MusicLogicNode
    {
        [XmlAttribute(AttributeName = "switch")]
        public String Switch { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public String Value { get; set; }

    }
}
