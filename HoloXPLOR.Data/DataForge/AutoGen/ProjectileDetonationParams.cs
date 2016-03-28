using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ProjectileDetonationParams")]
    public partial class ProjectileDetonationParams
    {
        [XmlAttribute(AttributeName = "armTime")]
        public Single ArmTime { get; set; }

        [XmlAttribute(AttributeName = "safeDistance")]
        public Single SafeDistance { get; set; }

        [XmlAttribute(AttributeName = "destructDelay")]
        public Single DestructDelay { get; set; }

        [XmlAttribute(AttributeName = "explodeOnImpact")]
        public Boolean ExplodeOnImpact { get; set; }

        [XmlAttribute(AttributeName = "explodeOnExpire")]
        public Boolean ExplodeOnExpire { get; set; }

        [XmlAttribute(AttributeName = "explodeOnTargetRange")]
        public Boolean ExplodeOnTargetRange { get; set; }

        [XmlElement(ElementName = "explosionParams")]
        public ExplosionParams ExplosionParams { get; set; }

    }
}
