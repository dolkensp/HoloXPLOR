using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ExplosionParams")]
    public partial class ExplosionParams
    {
        [XmlAttribute(AttributeName = "friendlyFire")]
        public FriendyFireType FriendlyFire { get; set; }

        [XmlAttribute(AttributeName = "minRadius")]
        public Single MinRadius { get; set; }

        [XmlAttribute(AttributeName = "maxRadius")]
        public Single MaxRadius { get; set; }

        [XmlAttribute(AttributeName = "soundRadius")]
        public Single SoundRadius { get; set; }

        [XmlAttribute(AttributeName = "minPhysRadius")]
        public Single MinPhysRadius { get; set; }

        [XmlAttribute(AttributeName = "maxPhysRadius")]
        public Single MaxPhysRadius { get; set; }

        [XmlAttribute(AttributeName = "pressure")]
        public Single Pressure { get; set; }

        [XmlAttribute(AttributeName = "holeSize")]
        public Single HoleSize { get; set; }

        [XmlAttribute(AttributeName = "terrainHoleSize")]
        public Single TerrainHoleSize { get; set; }

        [XmlAttribute(AttributeName = "maxblurdist")]
        public Single Maxblurdist { get; set; }

        [XmlAttribute(AttributeName = "effectScale")]
        public Single EffectScale { get; set; }

        [XmlAttribute(AttributeName = "useRandomScale")]
        public Boolean UseRandomScale { get; set; }

        [XmlAttribute(AttributeName = "effectScaleMin")]
        public Single EffectScaleMin { get; set; }

        [XmlAttribute(AttributeName = "effectScaleMax")]
        public Single EffectScaleMax { get; set; }

        [XmlElement(ElementName = "damage")]
        public DamageInfo Damage { get; set; }

        [XmlArray(ElementName = "flashbangParams")]
        [XmlArrayItem(Type = typeof(ExplosionFlashbangParams))]
        public ExplosionFlashbangParams[] FlashbangParams { get; set; }

        [XmlAttribute(AttributeName = "hitType")]
        public String HitType { get; set; }

        [XmlElement(ElementName = "effect")]
        public GlobalResourceParticle Effect { get; set; }

        [XmlElement(ElementName = "failedEffect")]
        public GlobalResourceParticle FailedEffect { get; set; }

        [XmlElement(ElementName = "sound")]
        public GlobalResourceAudio Sound { get; set; }

        [XmlElement(ElementName = "failedSound")]
        public GlobalResourceAudio FailedSound { get; set; }

    }
}
