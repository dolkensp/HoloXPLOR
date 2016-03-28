using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "C4ProjectileParams")]
    public partial class C4ProjectileParams : GrenadeProjectileParams
    {
        [XmlElement(ElementName = "armedMaterial")]
        public GlobalResourceMaterial ArmedMaterial { get; set; }

        [XmlElement(ElementName = "disarmedMaterial")]
        public GlobalResourceMaterial DisarmedMaterial { get; set; }

        [XmlElement(ElementName = "armedLightColour")]
        public RGBA ArmedLightColour { get; set; }

        [XmlElement(ElementName = "disarmedLightColour")]
        public RGBA DisarmedLightColour { get; set; }

        [XmlAttribute(AttributeName = "lightRadius")]
        public Single LightRadius { get; set; }

        [XmlAttribute(AttributeName = "specularMultiplier")]
        public Single SpecularMultiplier { get; set; }

        [XmlAttribute(AttributeName = "pulseMinColorMultiplier")]
        public Single PulseMinColorMultiplier { get; set; }

        [XmlAttribute(AttributeName = "pulseBeatsPerSecond")]
        public Single PulseBeatsPerSecond { get; set; }

    }
}
