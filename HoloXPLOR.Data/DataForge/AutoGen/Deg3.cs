using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "Deg3")]
    public partial class Deg3
    {
        [XmlAttribute(AttributeName = "x")]
        public Single X { get; set; }

        [XmlAttribute(AttributeName = "y")]
        public Single Y { get; set; }

        [XmlAttribute(AttributeName = "z")]
        public Single Z { get; set; }

    }
}
