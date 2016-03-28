using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "GrenadeProjectileParams")]
    public partial class GrenadeProjectileParams : ProjectileParams
    {
        [XmlAttribute(AttributeName = "impactLifetime")]
        public Single ImpactLifetime { get; set; }

        [XmlAttribute(AttributeName = "detonateOnActorImpact")]
        public Boolean DetonateOnActorImpact { get; set; }

        [XmlAttribute(AttributeName = "detonateOnImpact")]
        public Boolean DetonateOnImpact { get; set; }

        [XmlAttribute(AttributeName = "allowDetonationDelay")]
        public Boolean AllowDetonationDelay { get; set; }

        [XmlElement(ElementName = "cookStartSound")]
        public GlobalResourceAudio CookStartSound { get; set; }

        [XmlElement(ElementName = "cookStopSound")]
        public GlobalResourceAudio CookStopSound { get; set; }

    }
}
