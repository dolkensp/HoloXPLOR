using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "StarCitizenCampaign")]
    public partial class StarCitizenCampaign
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlArray(ElementName = "campaign")]
        [XmlArrayItem(Type = typeof(StarCitizenCampaignType))]
        [XmlArrayItem(Type = typeof(PersistentUniverseCampaign))]
        [XmlArrayItem(Type = typeof(StandAloneCampaign))]
        public StarCitizenCampaignType[] Campaign { get; set; }

    }
}
