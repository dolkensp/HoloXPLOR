using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SEffectInputParamsLight")]
    public partial class SEffectInputParamsLight : SEffectInputParamsDC
    {
        [XmlAttribute(AttributeName = "Type")]
        public ELightInputs Type { get; set; }

    }
}
