using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTSetControlledEntity")]
    public partial class BTSetControlledEntity : BTDecorator
    {
        [XmlArray(ElementName = "EntityId")]
        [XmlArrayItem(Type = typeof(BTInputEntityId))]
        [XmlArrayItem(Type = typeof(BTInputEntityIdVar))]
        [XmlArrayItem(Type = typeof(BTInputEntityIdBB))]
        public BTInputEntityId[] EntityId { get; set; }

    }
}
