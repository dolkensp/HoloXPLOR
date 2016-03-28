using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SEffectParamParticle")]
    public partial class SEffectParamParticle : SEffectParams
    {
        [XmlArray(ElementName = "InputVariables")]
        [XmlArrayItem(Type = typeof(SEffectInputParamsParticle))]
        public SEffectInputParamsParticle[] InputVariables { get; set; }

    }
}
