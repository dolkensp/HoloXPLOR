using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "RGB8")]
    public partial class RGB8
    {
        [XmlAttribute(AttributeName = "r")]
        public Byte R { get; set; }

        [XmlAttribute(AttributeName = "g")]
        public Byte G { get; set; }

        [XmlAttribute(AttributeName = "b")]
        public Byte B { get; set; }

    }
}
