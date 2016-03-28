using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SEffectInputParamsDC")]
    public partial class SEffectInputParamsDC
    {
        [XmlAttribute(AttributeName = "VarName")]
        public String VarName { get; set; }

        [XmlAttribute(AttributeName = "ParamName")]
        public String ParamName { get; set; }

        [XmlAttribute(AttributeName = "MinRange")]
        public Single MinRange { get; set; }

        [XmlAttribute(AttributeName = "MaxRange")]
        public Single MaxRange { get; set; }

        [XmlAttribute(AttributeName = "Multiplier")]
        public Single Multiplier { get; set; }

        [XmlAttribute(AttributeName = "LerpTime")]
        public Single LerpTime { get; set; }

        [XmlElement(ElementName = "VecGoal")]
        public Vec3 VecGoal { get; set; }

        [XmlAttribute(AttributeName = "DefaultValue")]
        public Single DefaultValue { get; set; }

        [XmlElement(ElementName = "Axis")]
        public Vec3 Axis { get; set; }

    }
}
