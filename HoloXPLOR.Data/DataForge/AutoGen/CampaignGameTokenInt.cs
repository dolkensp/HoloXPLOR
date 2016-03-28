using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CampaignGameTokenInt")]
    public partial class CampaignGameTokenInt : CampaignGameTokenBase
    {
        [XmlAttribute(AttributeName = "token")]
        public String Token { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public Int32 Value { get; set; }

    }
}
