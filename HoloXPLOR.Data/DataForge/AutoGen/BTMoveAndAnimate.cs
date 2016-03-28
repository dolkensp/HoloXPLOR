using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTMoveAndAnimate")]
    public partial class BTMoveAndAnimate : BTNode
    {
        [XmlArray(ElementName = "Destination")]
        [XmlArrayItem(Type = typeof(BTInput_MoveAndAnimate_Destination))]
        [XmlArrayItem(Type = typeof(BTInput_MoveAndAnimate_Destination_Var))]
        [XmlArrayItem(Type = typeof(BTInput_MoveAndAnimate_Destination_BB))]
        public BTInput_MoveAndAnimate_Destination[] Destination { get; set; }

        [XmlArray(ElementName = "Direction")]
        [XmlArrayItem(Type = typeof(BTInputVec3))]
        [XmlArrayItem(Type = typeof(BTInputVec3Var))]
        [XmlArrayItem(Type = typeof(BTInputVec3BB))]
        public BTInputVec3[] Direction { get; set; }

        [XmlArray(ElementName = "Speed")]
        [XmlArrayItem(Type = typeof(BTInputString))]
        [XmlArrayItem(Type = typeof(BTInputStringValue))]
        [XmlArrayItem(Type = typeof(BTInputStringVar))]
        [XmlArrayItem(Type = typeof(BTInputStringBB))]
        public BTInputString[] Speed { get; set; }

        [XmlArray(ElementName = "Stance")]
        [XmlArrayItem(Type = typeof(BTInputString))]
        [XmlArrayItem(Type = typeof(BTInputStringValue))]
        [XmlArrayItem(Type = typeof(BTInputStringVar))]
        [XmlArrayItem(Type = typeof(BTInputStringBB))]
        public BTInputString[] Stance { get; set; }

        [XmlArray(ElementName = "FragmentID")]
        [XmlArrayItem(Type = typeof(BTInputString))]
        [XmlArrayItem(Type = typeof(BTInputStringValue))]
        [XmlArrayItem(Type = typeof(BTInputStringVar))]
        [XmlArrayItem(Type = typeof(BTInputStringBB))]
        public BTInputString[] FragmentID { get; set; }

        [XmlArray(ElementName = "FragmentTag")]
        [XmlArrayItem(Type = typeof(BTInputString))]
        [XmlArrayItem(Type = typeof(BTInputStringValue))]
        [XmlArrayItem(Type = typeof(BTInputStringVar))]
        [XmlArrayItem(Type = typeof(BTInputStringBB))]
        public BTInputString[] FragmentTag { get; set; }

        [XmlArray(ElementName = "DirectionTolerance")]
        [XmlArrayItem(Type = typeof(BTInputFloat))]
        [XmlArrayItem(Type = typeof(BTInputFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputFloatVar))]
        [XmlArrayItem(Type = typeof(BTInputFloatBB))]
        public BTInputFloat[] DirectionTolerance { get; set; }

        [XmlArray(ElementName = "LoopDuration")]
        [XmlArrayItem(Type = typeof(BTInputFloat))]
        [XmlArrayItem(Type = typeof(BTInputFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputFloatVar))]
        [XmlArrayItem(Type = typeof(BTInputFloatBB))]
        public BTInputFloat[] LoopDuration { get; set; }

        [XmlArray(ElementName = "SlaveId")]
        [XmlArrayItem(Type = typeof(BTInputGenericId))]
        [XmlArrayItem(Type = typeof(BTInputGenericIdVar))]
        [XmlArrayItem(Type = typeof(BTInputGenericIdBB))]
        public BTInputGenericId[] SlaveId { get; set; }

        [XmlArray(ElementName = "SlaveId2")]
        [XmlArrayItem(Type = typeof(BTInputGenericId))]
        [XmlArrayItem(Type = typeof(BTInputGenericIdVar))]
        [XmlArrayItem(Type = typeof(BTInputGenericIdBB))]
        public BTInputGenericId[] SlaveId2 { get; set; }

    }
}
