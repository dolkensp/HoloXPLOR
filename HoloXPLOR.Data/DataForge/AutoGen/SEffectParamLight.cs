using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SEffectParamLight")]
    public partial class SEffectParamLight : SEffectParams
    {
        [XmlArray(ElementName = "InputVariables")]
        [XmlArrayItem(Type = typeof(SEffectInputParamsLight))]
        public SEffectInputParamsLight[] InputVariables { get; set; }

    }
}
