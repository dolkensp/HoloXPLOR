using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "MissionReward_REC")]
    public partial class MissionReward_REC : BaseMissionReward
    {
        [XmlAttribute(AttributeName = "RECAmount")]
        public Int32 RECAmount { get; set; }

    }
}
