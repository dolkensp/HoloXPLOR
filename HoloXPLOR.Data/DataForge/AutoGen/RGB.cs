using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "RGB")]
    public partial class RGB
    {
        [XmlAttribute(AttributeName = "r")]
        public Single R { get; set; }

        [XmlAttribute(AttributeName = "g")]
        public Single G { get; set; }

        [XmlAttribute(AttributeName = "b")]
        public Single B { get; set; }

    }
}
