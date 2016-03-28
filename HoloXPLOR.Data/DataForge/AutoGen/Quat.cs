using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "Quat")]
    public partial class Quat
    {
        [XmlElement(ElementName = "Rotation")]
        public Ang3 Rotation { get; set; }

    }
}
