using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ForceFeedbackEffect")]
    public partial class ForceFeedbackEffect
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "time")]
        public Single Time { get; set; }

        [XmlArray(ElementName = "MotorAB")]
        [XmlArrayItem(Type = typeof(ForceFeedbackMotor))]
        public ForceFeedbackMotor[] MotorAB { get; set; }

        [XmlArray(ElementName = "MotorA")]
        [XmlArrayItem(Type = typeof(ForceFeedbackMotor))]
        public ForceFeedbackMotor[] MotorA { get; set; }

        [XmlArray(ElementName = "MotorB")]
        [XmlArrayItem(Type = typeof(ForceFeedbackMotor))]
        public ForceFeedbackMotor[] MotorB { get; set; }

    }
}
