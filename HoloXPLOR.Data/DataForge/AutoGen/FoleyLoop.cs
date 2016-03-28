using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "FoleyLoop")]
    public partial class FoleyLoop
    {
        [XmlAttribute(AttributeName = "playTrigger")]
        public String PlayTrigger { get; set; }

        [XmlAttribute(AttributeName = "stopTrigger")]
        public String StopTrigger { get; set; }

        [XmlAttribute(AttributeName = "threshold")]
        public Single Threshold { get; set; }

    }
}
