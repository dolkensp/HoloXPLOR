using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTShip_FindObstacleToHit")]
    public partial class BTShip_FindObstacleToHit : BTNode
    {
        [XmlArray(ElementName = "MaxTime")]
        [XmlArrayItem(Type = typeof(BTInputFloat))]
        [XmlArrayItem(Type = typeof(BTInputFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputFloatVar))]
        [XmlArrayItem(Type = typeof(BTInputFloatBB))]
        public BTInputFloat[] MaxTime { get; set; }

        [XmlArray(ElementName = "MaxTurn")]
        [XmlArrayItem(Type = typeof(BTInputFloat))]
        [XmlArrayItem(Type = typeof(BTInputFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputFloatVar))]
        [XmlArrayItem(Type = typeof(BTInputFloatBB))]
        public BTInputFloat[] MaxTurn { get; set; }

        [XmlArray(ElementName = "Goal")]
        [XmlArrayItem(Type = typeof(BTOutput))]
        public BTOutput[] Goal { get; set; }

    }
}
