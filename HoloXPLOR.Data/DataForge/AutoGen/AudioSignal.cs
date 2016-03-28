using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "AudioSignal")]
    public partial class AudioSignal
    {
        [XmlAttribute(AttributeName = "Name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "Trigger")]
        public String Trigger { get; set; }

    }
}
