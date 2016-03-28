using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "StandAloneChapter")]
    public partial class StandAloneChapter
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "level")]
        public Guid Level { get; set; }

        [XmlAttribute(AttributeName = "loadout")]
        public String Loadout { get; set; }

        [XmlArray(ElementName = "tokens")]
        [XmlArrayItem(Type = typeof(CampaignGameTokenBase))]
        [XmlArrayItem(Type = typeof(CampaignGameTokenBool))]
        [XmlArrayItem(Type = typeof(CampaignGameTokenInt))]
        public CampaignGameTokenBase[] Tokens { get; set; }

        [XmlAttribute(AttributeName = "nextChapter")]
        public String NextChapter { get; set; }

    }
}
