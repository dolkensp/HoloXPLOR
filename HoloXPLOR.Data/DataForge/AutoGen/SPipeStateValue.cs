using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SPipeStateValue")]
    public partial class SPipeStateValue
    {
        [XmlAttribute(AttributeName = "Value")]
        public Single Value { get; set; }

        [XmlAttribute(AttributeName = "Delay")]
        public Single Delay { get; set; }

        [XmlAttribute(AttributeName = "StateType")]
        public EPipeStateValType StateType { get; set; }

        [XmlAttribute(AttributeName = "ValueType")]
        public EPipeValueType ValueType { get; set; }

        [XmlAttribute(AttributeName = "OtherPipeClass")]
        public EPipeClass OtherPipeClass { get; set; }

        [XmlElement(ElementName = "Properties")]
        public SPipeStateValueProperties Properties { get; set; }

    }
}
