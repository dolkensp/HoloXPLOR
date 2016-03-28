using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BulletProjectileParams")]
    public partial class BulletProjectileParams : ProjectileParams
    {
        [XmlElement(ElementName = "damage")]
        public DamageInfo Damage { get; set; }

        [XmlAttribute(AttributeName = "hitType")]
        public String HitType { get; set; }

        [XmlArray(ElementName = "damageDropParams")]
        [XmlArrayItem(Type = typeof(BulletDamageDropParams))]
        public BulletDamageDropParams[] DamageDropParams { get; set; }

        [XmlElement(ElementName = "pierceabilityParams")]
        public BulletPierceabilityParams PierceabilityParams { get; set; }

        [XmlElement(ElementName = "visualParams")]
        public BulletVisualParams VisualParams { get; set; }

    }
}
