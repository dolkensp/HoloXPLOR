using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SPipeConnection")]
    public partial class SPipeConnection
    {
        [XmlAttribute(AttributeName = "PipeClass")]
        public EPipeClass PipeClass { get; set; }

        [XmlElement(ElementName = "Properties")]
        public SPipeProperties Properties { get; set; }

        [XmlElement(ElementName = "StateLevels")]
        public SPipeStateLevels StateLevels { get; set; }

        [XmlElement(ElementName = "Priority")]
        public SPipePriority Priority { get; set; }

        [XmlElement(ElementName = "Pool")]
        public SPipePool Pool { get; set; }

        [XmlElement(ElementName = "Signal")]
        public SPipeSignal Signal { get; set; }

        [XmlArray(ElementName = "States")]
        [XmlArrayItem(Type = typeof(SPipeState))]
        public SPipeState[] States { get; set; }

    }
}
