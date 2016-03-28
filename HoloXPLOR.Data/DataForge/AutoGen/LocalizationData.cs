using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "LocalizationData")]
    public partial class LocalizationData
    {
        [XmlAttribute(AttributeName = "Tag")]
        public String Tag { get; set; }

        [XmlArray(ElementName = "Filenames")]
        [XmlArrayItem(Type = typeof(ProjectileParams))]
        [XmlArrayItem(Type = typeof(RocketProjectileParams))]
        [XmlArrayItem(Type = typeof(CounterMeasureProjectileParams))]
        [XmlArrayItem(Type = typeof(ShatterRocketProjectileParams))]
        [XmlArrayItem(Type = typeof(GrenadeProjectileParams))]
        [XmlArrayItem(Type = typeof(SmokeGrenadeProjectileParams))]
        [XmlArrayItem(Type = typeof(C4ProjectileParams))]
        [XmlArrayItem(Type = typeof(BulletProjectileParams))]
        public String[] Filenames { get; set; }

    }
}
