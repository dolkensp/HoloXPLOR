using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SPipeDistortion")]
    public partial class SPipeDistortion
    {
        [XmlAttribute(AttributeName = "Capacity")]
        public Single Capacity { get; set; }

        [XmlAttribute(AttributeName = "Threshold")]
        public Single Threshold { get; set; }

        [XmlAttribute(AttributeName = "Decay")]
        public Single Decay { get; set; }

    }
}
