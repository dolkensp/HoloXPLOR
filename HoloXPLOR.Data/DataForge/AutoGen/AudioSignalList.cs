using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "AudioSignalList")]
    public partial class AudioSignalList
    {
        [XmlArray(ElementName = "Signals")]
        [XmlArrayItem(Type = typeof(AudioSignal))]
        public AudioSignal[] Signals { get; set; }

    }
}
