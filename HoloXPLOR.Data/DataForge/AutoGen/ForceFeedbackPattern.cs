using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ForceFeedbackPattern")]
    public partial class ForceFeedbackPattern
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "samples")]
        public String Samples { get; set; }

    }
}
