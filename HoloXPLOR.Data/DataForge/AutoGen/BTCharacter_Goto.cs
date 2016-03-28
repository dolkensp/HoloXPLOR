using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTCharacter_Goto")]
    public partial class BTCharacter_Goto : BTNode
    {
        [XmlArray(ElementName = "Destination")]
        [XmlArrayItem(Type = typeof(BTInput_Character_Goto_Destination))]
        [XmlArrayItem(Type = typeof(BTInput_Character_Goto_Destination_Var))]
        [XmlArrayItem(Type = typeof(BTInput_Character_Goto_Destination_BB))]
        public BTInput_Character_Goto_Destination[] Destination { get; set; }

        [XmlArray(ElementName = "Speed")]
        [XmlArrayItem(Type = typeof(BTInput_Character_Goto_Speed))]
        [XmlArrayItem(Type = typeof(BTInput_Character_Goto_Speed_Float))]
        [XmlArrayItem(Type = typeof(BTInput_Character_Goto_Speed_String))]
        [XmlArrayItem(Type = typeof(BTInput_Character_Goto_Speed_Var))]
        [XmlArrayItem(Type = typeof(BTInput_Character_Goto_Speed_BB))]
        public BTInput_Character_Goto_Speed[] Speed { get; set; }

        [XmlArray(ElementName = "EndDistance")]
        [XmlArrayItem(Type = typeof(BTInputFloat))]
        [XmlArrayItem(Type = typeof(BTInputFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputFloatVar))]
        [XmlArrayItem(Type = typeof(BTInputFloatBB))]
        public BTInputFloat[] EndDistance { get; set; }

    }
}
