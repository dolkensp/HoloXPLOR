using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SEffectParamSound")]
    public partial class SEffectParamSound : SEffectParams
    {
        [XmlArray(ElementName = "InputVariables")]
        [XmlArrayItem(Type = typeof(SEffectInputParamsSound))]
        public SEffectInputParamsSound[] InputVariables { get; set; }

    }
}
