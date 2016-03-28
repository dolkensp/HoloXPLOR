using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SEntityEffectCoreParams")]
    public partial class SEntityEffectCoreParams
    {
        [XmlArray(ElementName = "EffectParams")]
        [XmlArrayItem(Type = typeof(SEffectParams))]
        [XmlArrayItem(Type = typeof(SEffectParamParticle))]
        [XmlArrayItem(Type = typeof(SEffectParamLight))]
        [XmlArrayItem(Type = typeof(SEffectParamMaterial))]
        [XmlArrayItem(Type = typeof(SEffectParamSound))]
        [XmlArrayItem(Type = typeof(SEffectParamJoint))]
        public SEffectParams[] EffectParams { get; set; }

    }
}
