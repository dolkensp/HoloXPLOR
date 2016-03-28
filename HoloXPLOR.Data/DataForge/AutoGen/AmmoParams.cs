using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "AmmoParams")]
    public partial class AmmoParams
    {
        [XmlAttribute(AttributeName = "spawnType")]
        public AmmoSpawnType SpawnType { get; set; }

        [XmlAttribute(AttributeName = "size")]
        public Byte Size { get; set; }

        [XmlAttribute(AttributeName = "ammoCategory")]
        public String AmmoCategory { get; set; }

        [XmlAttribute(AttributeName = "UIIconType")]
        public String UIIconType { get; set; }

        [XmlAttribute(AttributeName = "hitPoints")]
        public Single HitPoints { get; set; }

        [XmlAttribute(AttributeName = "lifetime")]
        public Single Lifetime { get; set; }

        [XmlAttribute(AttributeName = "showtime")]
        public Single Showtime { get; set; }

        [XmlAttribute(AttributeName = "inheritVelocity")]
        public Single InheritVelocity { get; set; }

        [XmlAttribute(AttributeName = "hitRecoil")]
        public String HitRecoil { get; set; }

        [XmlAttribute(AttributeName = "bulletType")]
        public Int32 BulletType { get; set; }

        [XmlAttribute(AttributeName = "speed")]
        public Single Speed { get; set; }

        [XmlAttribute(AttributeName = "noBulletHits")]
        public Boolean NoBulletHits { get; set; }

        [XmlAttribute(AttributeName = "quietRemoval")]
        public Boolean QuietRemoval { get; set; }

        [XmlElement(ElementName = "whizSound")]
        public GlobalResourceAudio WhizSound { get; set; }

        [XmlAttribute(AttributeName = "whizSoundDistance")]
        public Single WhizSoundDistance { get; set; }

        [XmlElement(ElementName = "ricochetSound")]
        public GlobalResourceAudio RicochetSound { get; set; }

        [XmlArray(ElementName = "geometryResourceParams")]
        [XmlArrayItem(Type = typeof(SGeometryResourceParams))]
        public SGeometryResourceParams[] GeometryResourceParams { get; set; }

        [XmlArray(ElementName = "physicsControllerParams")]
        [XmlArrayItem(Type = typeof(SEntityPhysicsControllerParams))]
        [XmlArrayItem(Type = typeof(SEntityRigidPhysicsControllerParams))]
        [XmlArrayItem(Type = typeof(SEntityParticlePhysicsControllerParams))]
        public SEntityPhysicsControllerParams[] PhysicsControllerParams { get; set; }

        [XmlArray(ElementName = "entityEffectParams")]
        [XmlArrayItem(Type = typeof(SEntityEffectCoreParams))]
        public SEntityEffectCoreParams[] EntityEffectParams { get; set; }

        [XmlArray(ElementName = "lightPoolParams")]
        [XmlArrayItem(Type = typeof(PooledLightData))]
        public PooledLightData[] LightPoolParams { get; set; }

        [XmlArray(ElementName = "projectileParams")]
        [XmlArrayItem(Type = typeof(ProjectileParams))]
        [XmlArrayItem(Type = typeof(RocketProjectileParams))]
        [XmlArrayItem(Type = typeof(CounterMeasureProjectileParams))]
        [XmlArrayItem(Type = typeof(ShatterRocketProjectileParams))]
        [XmlArrayItem(Type = typeof(GrenadeProjectileParams))]
        [XmlArrayItem(Type = typeof(SmokeGrenadeProjectileParams))]
        [XmlArrayItem(Type = typeof(C4ProjectileParams))]
        [XmlArrayItem(Type = typeof(BulletProjectileParams))]
        public ProjectileParams[] ProjectileParams { get; set; }

    }
}
