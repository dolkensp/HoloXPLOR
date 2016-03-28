using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "MusicLogicEvent")]
    public partial class MusicLogicEvent
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

    }
}
