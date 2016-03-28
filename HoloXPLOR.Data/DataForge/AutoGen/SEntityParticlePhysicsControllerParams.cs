using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SEntityParticlePhysicsControllerParams")]
    public partial class SEntityParticlePhysicsControllerParams : SEntityPhysicsControllerParams
    {
        [XmlAttribute(AttributeName = "pierceability")]
        public UInt32 Pierceability { get; set; }

        [XmlAttribute(AttributeName = "radius")]
        public Single Radius { get; set; }

        [XmlAttribute(AttributeName = "accThrust")]
        public Single AccThrust { get; set; }

        [XmlAttribute(AttributeName = "airResistance")]
        public Single AirResistance { get; set; }

        [XmlAttribute(AttributeName = "rayCollision")]
        public Boolean RayCollision { get; set; }

        [XmlAttribute(AttributeName = "traceable")]
        public Boolean Traceable { get; set; }

        [XmlAttribute(AttributeName = "singleContact")]
        public Boolean SingleContact { get; set; }

        [XmlAttribute(AttributeName = "constantOrientation")]
        public Boolean ConstantOrientation { get; set; }

        [XmlAttribute(AttributeName = "noRoll")]
        public Boolean NoRoll { get; set; }

        [XmlAttribute(AttributeName = "noSpin")]
        public Boolean NoSpin { get; set; }

        [XmlAttribute(AttributeName = "noPathAlignment")]
        public Boolean NoPathAlignment { get; set; }

        [XmlAttribute(AttributeName = "noSelfCollision")]
        public Boolean NoSelfCollision { get; set; }

        [XmlAttribute(AttributeName = "noImpulse")]
        public Boolean NoImpulse { get; set; }

        [XmlAttribute(AttributeName = "decoupleHeading")]
        public Boolean DecoupleHeading { get; set; }

    }
}
