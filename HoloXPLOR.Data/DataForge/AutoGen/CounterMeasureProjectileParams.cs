using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CounterMeasureProjectileParams")]
    public partial class CounterMeasureProjectileParams : ProjectileParams
    {
        [XmlElement(ElementName = "launchParticle")]
        public GlobalResourceParticle LaunchParticle { get; set; }

        [XmlElement(ElementName = "trailParticle")]
        public GlobalResourceParticle TrailParticle { get; set; }

        [XmlArray(ElementName = "typeParams")]
        [XmlArrayItem(Type = typeof(CounterMeasureBaseParams))]
        [XmlArrayItem(Type = typeof(CounterMeasureChaffParams))]
        [XmlArrayItem(Type = typeof(CounterMeasureFlareParams))]
        public CounterMeasureBaseParams[] TypeParams { get; set; }

    }
}
