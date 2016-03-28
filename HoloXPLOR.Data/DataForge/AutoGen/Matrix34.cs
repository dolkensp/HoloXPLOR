using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "Matrix34")]
    public partial class Matrix34
    {
        [XmlElement(ElementName = "Rotation")]
        public Ang3 Rotation { get; set; }

        [XmlElement(ElementName = "Position")]
        public Vec3 Position { get; set; }

    }
}
