using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "FoleyOneShot")]
    public partial class FoleyOneShot
    {
        [XmlAttribute(AttributeName = "trigger")]
        public String Trigger { get; set; }

        [XmlAttribute(AttributeName = "threshold")]
        public Single Threshold { get; set; }

        [XmlAttribute(AttributeName = "playOnRising")]
        public Boolean PlayOnRising { get; set; }

        [XmlAttribute(AttributeName = "axis")]
        public Guid Axis { get; set; }

    }
}
