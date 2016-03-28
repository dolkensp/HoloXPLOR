using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "StandAloneSeason")]
    public partial class StandAloneSeason
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlArray(ElementName = "episodes")]
        [XmlArrayItem(Type = typeof(StandAloneEpisode))]
        public StandAloneEpisode[] Episodes { get; set; }

    }
}
