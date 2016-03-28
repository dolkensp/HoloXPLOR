using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CampaignGameTokenBool")]
    public partial class CampaignGameTokenBool : CampaignGameTokenBase
    {
        [XmlAttribute(AttributeName = "token")]
        public String Token { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public Boolean Value { get; set; }

    }
}
