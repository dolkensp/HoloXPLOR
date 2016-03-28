using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "AwardService_Config")]
    public partial class AwardService_Config
    {
        [XmlArray(ElementName = "Awards")]
        [XmlArrayItem(Type = typeof(AwardService_Award))]
        public AwardService_Award[] Awards { get; set; }

    }
}
