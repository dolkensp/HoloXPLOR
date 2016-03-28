using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTTeleportEntity")]
    public partial class BTTeleportEntity : BTNode
    {
        [XmlArray(ElementName = "EntityId")]
        [XmlArrayItem(Type = typeof(BTInputEntityId))]
        [XmlArrayItem(Type = typeof(BTInputEntityIdVar))]
        [XmlArrayItem(Type = typeof(BTInputEntityIdBB))]
        public BTInputEntityId[] EntityId { get; set; }

        [XmlArray(ElementName = "Transform")]
        [XmlArrayItem(Type = typeof(BTInputTransform))]
        [XmlArrayItem(Type = typeof(BTInputTransformVar))]
        [XmlArrayItem(Type = typeof(BTInputTransformBB))]
        public BTInputTransform[] Transform { get; set; }

    }
}
