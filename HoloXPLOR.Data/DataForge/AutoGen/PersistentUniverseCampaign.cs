using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "PersistentUniverseCampaign")]
    public partial class PersistentUniverseCampaign : StarCitizenCampaignType
    {
        [XmlArray(ElementName = "chapters")]
        [XmlArrayItem(Type = typeof(StandAloneChapter))]
        [XmlArrayItem(Type = typeof(StandAloneChapterStart))]
        public StandAloneChapter[] Chapters { get; set; }

    }
}
