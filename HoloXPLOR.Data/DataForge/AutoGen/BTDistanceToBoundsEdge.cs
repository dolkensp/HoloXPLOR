using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTDistanceToBoundsEdge")]
    public partial class BTDistanceToBoundsEdge : BTNode
    {
        [XmlArray(ElementName = "BoundsId")]
        [XmlArrayItem(Type = typeof(BTInputEntityId))]
        [XmlArrayItem(Type = typeof(BTInputEntityIdVar))]
        [XmlArrayItem(Type = typeof(BTInputEntityIdBB))]
        public BTInputEntityId[] BoundsId { get; set; }

        [XmlArray(ElementName = "Distance")]
        [XmlArrayItem(Type = typeof(BTOutput))]
        public BTOutput[] Distance { get; set; }

    }
}
