using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "LoadoutProbabilities")]
    public partial class LoadoutProbabilities
    {
        [XmlArray(ElementName = "probabilities")]
        [XmlArrayItem(Type = typeof(RandomLoadoutProbability))]
        public RandomLoadoutProbability[] Probabilities { get; set; }

    }
}
