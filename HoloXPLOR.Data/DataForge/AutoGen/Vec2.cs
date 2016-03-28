using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "Vec2")]
    public partial class Vec2
    {
        [XmlAttribute(AttributeName = "x")]
        public Single X { get; set; }

        [XmlAttribute(AttributeName = "y")]
        public Single Y { get; set; }

    }
}
