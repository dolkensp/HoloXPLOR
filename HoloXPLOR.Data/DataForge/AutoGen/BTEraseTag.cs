using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTEraseTag")]
    public partial class BTEraseTag : BTNode
    {
        [XmlArray(ElementName = "Tag")]
        [XmlArrayItem(Type = typeof(BTInputTag))]
        [XmlArrayItem(Type = typeof(BTInputTagValue))]
        [XmlArrayItem(Type = typeof(BTInputTagVar))]
        [XmlArrayItem(Type = typeof(BTInputTagBB))]
        public BTInputTag[] Tag { get; set; }

        [XmlArray(ElementName = "EntityId")]
        [XmlArrayItem(Type = typeof(BTInputEntityId))]
        [XmlArrayItem(Type = typeof(BTInputEntityIdVar))]
        [XmlArrayItem(Type = typeof(BTInputEntityIdBB))]
        public BTInputEntityId[] EntityId { get; set; }

        [XmlArray(ElementName = "IncludeChildren")]
        [XmlArrayItem(Type = typeof(BTInputBool))]
        [XmlArrayItem(Type = typeof(BTInputBoolValue))]
        [XmlArrayItem(Type = typeof(BTInputBoolVar))]
        [XmlArrayItem(Type = typeof(BTInputBoolBB))]
        public BTInputBool[] IncludeChildren { get; set; }

    }
}
