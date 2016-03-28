using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ForceFeedback")]
    public partial class ForceFeedback
    {
        [XmlArray(ElementName = "Patterns")]
        [XmlArrayItem(Type = typeof(ForceFeedbackPattern))]
        public ForceFeedbackPattern[] Patterns { get; set; }

        [XmlArray(ElementName = "Envelopes")]
        [XmlArrayItem(Type = typeof(ForceFeedbackEnvelope))]
        public ForceFeedbackEnvelope[] Envelopes { get; set; }

        [XmlArray(ElementName = "Effects")]
        [XmlArrayItem(Type = typeof(ForceFeedbackEffect))]
        public ForceFeedbackEffect[] Effects { get; set; }

    }
}
