using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SPipePool")]
    public partial class SPipePool
    {
        [XmlAttribute(AttributeName = "Capacity")]
        public Single Capacity { get; set; }

        [XmlAttribute(AttributeName = "FlowRate")]
        public Single FlowRate { get; set; }

        [XmlAttribute(AttributeName = "DecayRate")]
        public Single DecayRate { get; set; }

        [XmlElement(ElementName = "Properties")]
        public SPipePoolProperties Properties { get; set; }

    }
}
