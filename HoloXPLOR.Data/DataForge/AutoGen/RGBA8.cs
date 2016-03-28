using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "RGBA8")]
    public partial class RGBA8
    {
        [XmlAttribute(AttributeName = "r")]
        public Byte R { get; set; }

        [XmlAttribute(AttributeName = "g")]
        public Byte G { get; set; }

        [XmlAttribute(AttributeName = "b")]
        public Byte B { get; set; }

        [XmlAttribute(AttributeName = "a")]
        public Byte A { get; set; }

    }
}
