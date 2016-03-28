using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SeatScreenContainer")]
    public partial class SeatScreenContainer
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "helper")]
        public String Helper { get; set; }

        [XmlAttribute(AttributeName = "port")]
        public String Port { get; set; }

        [XmlAttribute(AttributeName = "container")]
        public String Container { get; set; }

        [XmlAttribute(AttributeName = "screenSpace")]
        public Boolean ScreenSpace { get; set; }

        [XmlAttribute(AttributeName = "useParentPort")]
        public Boolean UseParentPort { get; set; }

        [XmlAttribute(AttributeName = "scale")]
        public Single Scale { get; set; }

        [XmlElement(ElementName = "offset")]
        public Vec3 Offset { get; set; }

        [XmlElement(ElementName = "rotation")]
        public Deg3 Rotation { get; set; }

    }
}
