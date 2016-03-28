using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SeatReticleArchetype")]
    public partial class SeatReticleArchetype
    {
        [XmlAttribute(AttributeName = "fixed")]
        public Boolean Fixed { get; set; }

        [XmlAttribute(AttributeName = "look")]
        public Boolean Look { get; set; }

        [XmlAttribute(AttributeName = "velocity")]
        public Boolean Velocity { get; set; }

        [XmlAttribute(AttributeName = "control")]
        public Boolean Control { get; set; }

    }
}
