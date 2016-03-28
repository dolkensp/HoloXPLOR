using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTReplaceTag")]
    public partial class BTReplaceTag : BTNode
    {
        [XmlArray(ElementName = "OldTag")]
        [XmlArrayItem(Type = typeof(BTInputTag))]
        [XmlArrayItem(Type = typeof(BTInputTagValue))]
        [XmlArrayItem(Type = typeof(BTInputTagVar))]
        [XmlArrayItem(Type = typeof(BTInputTagBB))]
        public BTInputTag[] OldTag { get; set; }

        [XmlArray(ElementName = "NewTag")]
        [XmlArrayItem(Type = typeof(BTInputTag))]
        [XmlArrayItem(Type = typeof(BTInputTagValue))]
        [XmlArrayItem(Type = typeof(BTInputTagVar))]
        [XmlArrayItem(Type = typeof(BTInputTagBB))]
        public BTInputTag[] NewTag { get; set; }

        [XmlArray(ElementName = "EntityId")]
        [XmlArrayItem(Type = typeof(BTInputEntityId))]
        [XmlArrayItem(Type = typeof(BTInputEntityIdVar))]
        [XmlArrayItem(Type = typeof(BTInputEntityIdBB))]
        public BTInputEntityId[] EntityId { get; set; }

    }
}
