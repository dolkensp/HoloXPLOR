using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTShip_FindStuntSpline")]
    public partial class BTShip_FindStuntSpline : BTNode
    {
        [XmlArray(ElementName = "ExcludeId")]
        [XmlArrayItem(Type = typeof(BTInputEntityId))]
        [XmlArrayItem(Type = typeof(BTInputEntityIdVar))]
        [XmlArrayItem(Type = typeof(BTInputEntityIdBB))]
        public BTInputEntityId[] ExcludeId { get; set; }

        [XmlArray(ElementName = "StuntSplineId")]
        [XmlArrayItem(Type = typeof(BTOutput))]
        public BTOutput[] StuntSplineId { get; set; }

    }
}
