using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ShipArchetypeGroup")]
    public partial class ShipArchetypeGroup
    {
        [XmlArray(ElementName = "shipArchetypes")]
        [XmlArrayItem(Type = typeof(ProjectileParams))]
        [XmlArrayItem(Type = typeof(RocketProjectileParams))]
        [XmlArrayItem(Type = typeof(CounterMeasureProjectileParams))]
        [XmlArrayItem(Type = typeof(ShatterRocketProjectileParams))]
        [XmlArrayItem(Type = typeof(GrenadeProjectileParams))]
        [XmlArrayItem(Type = typeof(SmokeGrenadeProjectileParams))]
        [XmlArrayItem(Type = typeof(C4ProjectileParams))]
        [XmlArrayItem(Type = typeof(BulletProjectileParams))]
        public String[] ShipArchetypes { get; set; }

    }
}
