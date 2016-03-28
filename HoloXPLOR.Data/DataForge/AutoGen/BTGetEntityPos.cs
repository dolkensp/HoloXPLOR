using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTGetEntityPos")]
    public partial class BTGetEntityPos : BTNode
    {
        [XmlArray(ElementName = "EntityId")]
        [XmlArrayItem(Type = typeof(BTInputEntityId))]
        [XmlArrayItem(Type = typeof(BTInputEntityIdVar))]
        [XmlArrayItem(Type = typeof(BTInputEntityIdBB))]
        public BTInputEntityId[] EntityId { get; set; }

        [XmlArray(ElementName = "Position")]
        [XmlArrayItem(Type = typeof(BTOutput))]
        public BTOutput[] Position { get; set; }

    }
}
