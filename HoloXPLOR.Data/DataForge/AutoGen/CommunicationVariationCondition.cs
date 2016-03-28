using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CommunicationVariationCondition")]
    public partial class CommunicationVariationCondition
    {
        [XmlAttribute(AttributeName = "expression")]
        public String Expression { get; set; }

    }
}
