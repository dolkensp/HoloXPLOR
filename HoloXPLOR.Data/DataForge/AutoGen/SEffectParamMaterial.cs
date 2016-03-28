using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SEffectParamMaterial")]
    public partial class SEffectParamMaterial : SEffectParams
    {
        [XmlArray(ElementName = "InputVariables")]
        [XmlArrayItem(Type = typeof(SEffectInputParamsMaterial))]
        public SEffectInputParamsMaterial[] InputVariables { get; set; }

    }
}
