using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ForceFeedbackEnvelope")]
    public partial class ForceFeedbackEnvelope
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "samples")]
        public String Samples { get; set; }

    }
}
