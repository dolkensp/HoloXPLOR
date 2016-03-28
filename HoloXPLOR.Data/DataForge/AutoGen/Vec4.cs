using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "Vec4")]
    public partial class Vec4
    {
        [XmlAttribute(AttributeName = "x")]
        public Single X { get; set; }

        [XmlAttribute(AttributeName = "y")]
        public Single Y { get; set; }

        [XmlAttribute(AttributeName = "z")]
        public Single Z { get; set; }

        [XmlAttribute(AttributeName = "w")]
        public Single W { get; set; }

    }
}
