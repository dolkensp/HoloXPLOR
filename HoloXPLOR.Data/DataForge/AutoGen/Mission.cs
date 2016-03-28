using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "Mission")]
    public partial class Mission
    {
        [XmlAttribute(AttributeName = "Title")]
        public String Title { get; set; }

        [XmlAttribute(AttributeName = "ShortTitle")]
        public String ShortTitle { get; set; }

        [XmlAttribute(AttributeName = "Description")]
        public String Description { get; set; }

        [XmlAttribute(AttributeName = "Type")]
        public Guid Type { get; set; }

        [XmlAttribute(AttributeName = "Secondary")]
        public Boolean Secondary { get; set; }

        [XmlAttribute(AttributeName = "AutoTrack")]
        public Boolean AutoTrack { get; set; }

        [XmlAttribute(AttributeName = "Repeatable")]
        public Boolean Repeatable { get; set; }

        [XmlArray(ElementName = "Reward")]
        [XmlArrayItem(Type = typeof(BaseMissionReward))]
        [XmlArrayItem(Type = typeof(MissionReward_REC))]
        public BaseMissionReward[] Reward { get; set; }

        [XmlArray(ElementName = "Objectives")]
        [XmlArrayItem(Type = typeof(MissionObjective))]
        public MissionObjective[] Objectives { get; set; }

    }
}
