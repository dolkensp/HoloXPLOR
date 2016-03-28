using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SOptimalTM")]
    public partial class SOptimalTM
    {
        [XmlAttribute(AttributeName = "DoSnap")]
        public Boolean DoSnap { get; set; }

        [XmlArray(ElementName = "Pos")]
        [XmlArrayItem(Type = typeof(Vec3))]
        public Vec3[] Pos { get; set; }

        [XmlArray(ElementName = "Rot")]
        [XmlArrayItem(Type = typeof(Quat))]
        public Quat[] Rot { get; set; }

    }
}
