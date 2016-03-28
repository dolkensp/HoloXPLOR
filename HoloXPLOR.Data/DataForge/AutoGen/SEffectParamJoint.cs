using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SEffectParamJoint")]
    public partial class SEffectParamJoint : SEffectParams
    {
        [XmlArray(ElementName = "InputVariables")]
        [XmlArrayItem(Type = typeof(SEffectInputParamsJoint))]
        public SEffectInputParamsJoint[] InputVariables { get; set; }

    }
}
