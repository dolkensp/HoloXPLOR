using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "RandomLoadoutProbability")]
    public partial class RandomLoadoutProbability
    {
        [XmlAttribute(AttributeName = "loadout")]
        public Guid Loadout { get; set; }

        [XmlAttribute(AttributeName = "probabilityWeight")]
        public UInt32 ProbabilityWeight { get; set; }

    }
}
