using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTFindRandomEntityWithTags")]
    public partial class BTFindRandomEntityWithTags : BTNode
    {
        [XmlArray(ElementName = "Tags")]
        [XmlArrayItem(Type = typeof(BTInputBlackboardArray))]
        [XmlArrayItem(Type = typeof(BTInputBlackboardArrayVar))]
        [XmlArrayItem(Type = typeof(BTInputBlackboardArrayBB))]
        public BTInputBlackboardArray[] Tags { get; set; }

        [XmlArray(ElementName = "ExcludeId")]
        [XmlArrayItem(Type = typeof(BTInputEntityId))]
        [XmlArrayItem(Type = typeof(BTInputEntityIdVar))]
        [XmlArrayItem(Type = typeof(BTInputEntityIdBB))]
        public BTInputEntityId[] ExcludeId { get; set; }

        [XmlArray(ElementName = "Range")]
        [XmlArrayItem(Type = typeof(BTInputFloat))]
        [XmlArrayItem(Type = typeof(BTInputFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputFloatVar))]
        [XmlArrayItem(Type = typeof(BTInputFloatBB))]
        public BTInputFloat[] Range { get; set; }

        [XmlArray(ElementName = "EntityId")]
        [XmlArrayItem(Type = typeof(BTOutput))]
        public BTOutput[] EntityId { get; set; }

    }
}
