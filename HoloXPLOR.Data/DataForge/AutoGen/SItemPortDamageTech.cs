using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SItemPortDamageTech")]
    public partial class SItemPortDamageTech
    {
        [XmlElement(ElementName = "size")]
        public Vec2 Size { get; set; }

        [XmlElement(ElementName = "offset")]
        public Vec2 Offset { get; set; }

    }
}
