using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTCharacter_ExactGoto")]
    public partial class BTCharacter_ExactGoto : BTNode
    {
        [XmlArray(ElementName = "Destination")]
        [XmlArrayItem(Type = typeof(BTInputPosition))]
        [XmlArrayItem(Type = typeof(BTInputPositionVar))]
        [XmlArrayItem(Type = typeof(BTInputPositionBB))]
        public BTInputPosition[] Destination { get; set; }

        [XmlArray(ElementName = "Direction")]
        [XmlArrayItem(Type = typeof(BTInputVec3))]
        [XmlArrayItem(Type = typeof(BTInputVec3Var))]
        [XmlArrayItem(Type = typeof(BTInputVec3BB))]
        public BTInputVec3[] Direction { get; set; }

        [XmlArray(ElementName = "Speed")]
        [XmlArrayItem(Type = typeof(BTInput_Character_ExactGoto_Speed))]
        [XmlArrayItem(Type = typeof(BTInput_Character_ExactGoto_Speed_Float))]
        [XmlArrayItem(Type = typeof(BTInput_Character_ExactGoto_Speed_String))]
        [XmlArrayItem(Type = typeof(BTInput_Character_ExactGoto_Speed_Var))]
        [XmlArrayItem(Type = typeof(BTInput_Character_ExactGoto_Speed_BB))]
        public BTInput_Character_ExactGoto_Speed[] Speed { get; set; }

    }
}
