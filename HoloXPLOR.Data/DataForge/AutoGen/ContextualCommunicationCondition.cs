using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ContextualCommunicationCondition")]
    public partial class ContextualCommunicationCondition
    {
        [XmlAttribute(AttributeName = "criteriaType")]
        public eContextualCommunicationCriteria CriteriaType { get; set; }

        [XmlAttribute(AttributeName = "customCriteria")]
        public String CustomCriteria { get; set; }

        [XmlAttribute(AttributeName = "numberValue")]
        public Single NumberValue { get; set; }

        [XmlAttribute(AttributeName = "stringValue")]
        public String StringValue { get; set; }

        [XmlAttribute(AttributeName = "operation")]
        public eCommunicationCriteriaOperant Operation { get; set; }

    }
}
