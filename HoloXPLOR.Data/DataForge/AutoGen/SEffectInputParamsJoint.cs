using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SEffectInputParamsJoint")]
    public partial class SEffectInputParamsJoint : SEffectInputParamsDC
    {
        [XmlAttribute(AttributeName = "Type")]
        public EJointInputs Type { get; set; }

    }
}
