using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SEffectInputParamsParticle")]
    public partial class SEffectInputParamsParticle : SEffectInputParamsDC
    {
        [XmlAttribute(AttributeName = "Type")]
        public EParticleInputs Type { get; set; }

    }
}
