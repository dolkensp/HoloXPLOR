using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "RGBA")]
    public partial class RGBA
    {
        [XmlAttribute(AttributeName = "r")]
        public Single R { get; set; }

        [XmlAttribute(AttributeName = "g")]
        public Single G { get; set; }

        [XmlAttribute(AttributeName = "b")]
        public Single B { get; set; }

        [XmlAttribute(AttributeName = "a")]
        public Single A { get; set; }

    }
}
