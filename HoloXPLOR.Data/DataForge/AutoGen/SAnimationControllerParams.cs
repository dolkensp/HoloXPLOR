using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SAnimationControllerParams")]
    public partial class SAnimationControllerParams
    {
        [XmlAttribute(AttributeName = "AnimationDatabase")]
        public String AnimationDatabase { get; set; }

        [XmlAttribute(AttributeName = "AnimationController")]
        public String AnimationController { get; set; }

        [XmlArray(ElementName = "ScopeContexts")]
        [XmlArrayItem(Type = typeof(ProjectileParams))]
        [XmlArrayItem(Type = typeof(RocketProjectileParams))]
        [XmlArrayItem(Type = typeof(CounterMeasureProjectileParams))]
        [XmlArrayItem(Type = typeof(ShatterRocketProjectileParams))]
        [XmlArrayItem(Type = typeof(GrenadeProjectileParams))]
        [XmlArrayItem(Type = typeof(SmokeGrenadeProjectileParams))]
        [XmlArrayItem(Type = typeof(C4ProjectileParams))]
        [XmlArrayItem(Type = typeof(BulletProjectileParams))]
        public String[] ScopeContexts { get; set; }

    }
}
