using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SeatScreen")]
    public partial class SeatScreen
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "screen")]
        public String Screen { get; set; }

        [XmlArray(ElementName = "containers")]
        [XmlArrayItem(Type = typeof(SeatScreenContainer))]
        public SeatScreenContainer[] Containers { get; set; }

    }
}
