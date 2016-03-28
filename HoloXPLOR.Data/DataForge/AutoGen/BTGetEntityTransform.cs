using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTGetEntityTransform")]
    public partial class BTGetEntityTransform : BTNode
    {
        [XmlArray(ElementName = "EntityId")]
        [XmlArrayItem(Type = typeof(BTInputEntityId))]
        [XmlArrayItem(Type = typeof(BTInputEntityIdVar))]
        [XmlArrayItem(Type = typeof(BTInputEntityIdBB))]
        public BTInputEntityId[] EntityId { get; set; }

        [XmlArray(ElementName = "Transform")]
        [XmlArrayItem(Type = typeof(BTOutput))]
        public BTOutput[] Transform { get; set; }

    }
}
