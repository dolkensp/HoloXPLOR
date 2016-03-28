using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SpawnBundleWaveDefinition")]
    public partial class SpawnBundleWaveDefinition
    {
        [XmlArray(ElementName = "waves")]
        [XmlArrayItem(Type = typeof(WaveDefinition))]
        public WaveDefinition[] Waves { get; set; }

    }
}
