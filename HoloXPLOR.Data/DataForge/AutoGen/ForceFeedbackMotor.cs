using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ForceFeedbackMotor")]
    public partial class ForceFeedbackMotor
    {
        [XmlAttribute(AttributeName = "frequency")]
        public Single Frequency { get; set; }

        [XmlAttribute(AttributeName = "pattern")]
        public String Pattern { get; set; }

        [XmlAttribute(AttributeName = "envelope")]
        public String Envelope { get; set; }

    }
}
