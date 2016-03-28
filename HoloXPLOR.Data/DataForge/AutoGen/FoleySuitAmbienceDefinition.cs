using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "FoleySuitAmbienceDefinition")]
    public partial class FoleySuitAmbienceDefinition
    {
        [XmlAttribute(AttributeName = "playTrigger")]
        public String PlayTrigger { get; set; }

        [XmlAttribute(AttributeName = "stopTrigger")]
        public String StopTrigger { get; set; }

    }
}
