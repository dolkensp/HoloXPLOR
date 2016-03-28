using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "StandAloneCampaign")]
    public partial class StandAloneCampaign : StarCitizenCampaignType
    {
        [XmlArray(ElementName = "seasons")]
        [XmlArrayItem(Type = typeof(StandAloneSeason))]
        public StandAloneSeason[] Seasons { get; set; }

    }
}
