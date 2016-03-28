using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "WaveDefinition")]
    public partial class WaveDefinition
    {
        [XmlAttribute(AttributeName = "waveId")]
        public Int32 WaveId { get; set; }

        [XmlAttribute(AttributeName = "staggerTime")]
        public Single StaggerTime { get; set; }

        [XmlArray(ElementName = "members")]
        [XmlArrayItem(Type = typeof(WaveMember))]
        public WaveMember[] Members { get; set; }

    }
}
