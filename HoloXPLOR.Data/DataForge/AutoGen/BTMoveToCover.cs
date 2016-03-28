using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTMoveToCover")]
    public partial class BTMoveToCover : BTNode
    {
        [XmlArray(ElementName = "CoverID")]
        [XmlArrayItem(Type = typeof(BTInputGenericId))]
        [XmlArrayItem(Type = typeof(BTInputGenericIdVar))]
        [XmlArrayItem(Type = typeof(BTInputGenericIdBB))]
        public BTInputGenericId[] CoverID { get; set; }

        [XmlArray(ElementName = "Speed")]
        [XmlArrayItem(Type = typeof(BTInput_MoveToCover_Speed))]
        [XmlArrayItem(Type = typeof(BTInput_MoveToCover_Speed_String))]
        [XmlArrayItem(Type = typeof(BTInput_MoveToCover_Speed_Var))]
        [XmlArrayItem(Type = typeof(BTInput_MoveToCover_Speed_BB))]
        public BTInput_MoveToCover_Speed[] Speed { get; set; }

        [XmlArray(ElementName = "Stance")]
        [XmlArrayItem(Type = typeof(BTInput_MoveToCover_Stance))]
        [XmlArrayItem(Type = typeof(BTInput_MoveToCover_Stance_String))]
        [XmlArrayItem(Type = typeof(BTInput_MoveToCover_Stance_Var))]
        [XmlArrayItem(Type = typeof(BTInput_MoveToCover_Stance_BB))]
        public BTInput_MoveToCover_Stance[] Stance { get; set; }

        [XmlArray(ElementName = "EndDistance")]
        [XmlArrayItem(Type = typeof(BTInputFloat))]
        [XmlArrayItem(Type = typeof(BTInputFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputFloatVar))]
        [XmlArrayItem(Type = typeof(BTInputFloatBB))]
        public BTInputFloat[] EndDistance { get; set; }

    }
}
