using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SEffectInputParamsMaterial")]
    public partial class SEffectInputParamsMaterial : SEffectInputParamsDC
    {
        [XmlAttribute(AttributeName = "Type")]
        public EMaterialInputs Type { get; set; }

    }
}
