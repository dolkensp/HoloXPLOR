using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "QuatT")]
    public partial class QuatT
    {
        [XmlElement(ElementName = "Rotation")]
        public Ang3 Rotation { get; set; }

        [XmlElement(ElementName = "Position")]
        public Vec3 Position { get; set; }

    }
}
