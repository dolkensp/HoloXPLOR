using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTAttachEntity")]
    public partial class BTAttachEntity : BTNode
    {
        [XmlArray(ElementName = "EntityId")]
        [XmlArrayItem(Type = typeof(BTInputEntityId))]
        [XmlArrayItem(Type = typeof(BTInputEntityIdVar))]
        [XmlArrayItem(Type = typeof(BTInputEntityIdBB))]
        public BTInputEntityId[] EntityId { get; set; }

        [XmlArray(ElementName = "AttachPoint")]
        [XmlArrayItem(Type = typeof(BTInputString))]
        [XmlArrayItem(Type = typeof(BTInputStringValue))]
        [XmlArrayItem(Type = typeof(BTInputStringVar))]
        [XmlArrayItem(Type = typeof(BTInputStringBB))]
        public BTInputString[] AttachPoint { get; set; }

    }
}
