using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SEffectInputParamsSound")]
    public partial class SEffectInputParamsSound : SEffectInputParamsDC
    {
        [XmlAttribute(AttributeName = "Type")]
        public ESoundInputs Type { get; set; }

    }
}
