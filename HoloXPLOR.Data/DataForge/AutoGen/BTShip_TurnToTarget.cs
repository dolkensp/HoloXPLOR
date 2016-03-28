using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTShip_TurnToTarget")]
    public partial class BTShip_TurnToTarget : BTNode
    {
        [XmlArray(ElementName = "Target")]
        [XmlArrayItem(Type = typeof(BTInput_Ship_TurnToTarget_Target))]
        [XmlArrayItem(Type = typeof(BTInput_Ship_TurnToTarget_Target_Var))]
        [XmlArrayItem(Type = typeof(BTInput_Ship_TurnToTarget_Target_BB))]
        public BTInput_Ship_TurnToTarget_Target[] Target { get; set; }

        [XmlArray(ElementName = "MaintainDirection")]
        [XmlArrayItem(Type = typeof(BTInputBool))]
        [XmlArrayItem(Type = typeof(BTInputBoolValue))]
        [XmlArrayItem(Type = typeof(BTInputBoolVar))]
        [XmlArrayItem(Type = typeof(BTInputBoolBB))]
        public BTInputBool[] MaintainDirection { get; set; }

        [XmlArray(ElementName = "Tolerance")]
        [XmlArrayItem(Type = typeof(BTInputFloat))]
        [XmlArrayItem(Type = typeof(BTInputFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputFloatVar))]
        [XmlArrayItem(Type = typeof(BTInputFloatBB))]
        public BTInputFloat[] Tolerance { get; set; }

    }
}
