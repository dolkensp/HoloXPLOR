using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTMove")]
    public partial class BTMove : BTNode
    {
        [XmlArray(ElementName = "Destination")]
        [XmlArrayItem(Type = typeof(BTInput_Move_Destination))]
        [XmlArrayItem(Type = typeof(BTInput_Move_Destination_Var))]
        [XmlArrayItem(Type = typeof(BTInput_Move_Destination_BB))]
        public BTInput_Move_Destination[] Destination { get; set; }

        [XmlArray(ElementName = "Speed")]
        [XmlArrayItem(Type = typeof(BTInput_Move_Speed))]
        [XmlArrayItem(Type = typeof(BTInput_Move_Speed_String))]
        [XmlArrayItem(Type = typeof(BTInput_Move_Speed_Var))]
        [XmlArrayItem(Type = typeof(BTInput_Move_Speed_BB))]
        public BTInput_Move_Speed[] Speed { get; set; }

        [XmlArray(ElementName = "Stance")]
        [XmlArrayItem(Type = typeof(BTInput_Move_Stance))]
        [XmlArrayItem(Type = typeof(BTInput_Move_Stance_String))]
        [XmlArrayItem(Type = typeof(BTInput_Move_Stance_Var))]
        [XmlArrayItem(Type = typeof(BTInput_Move_Stance_BB))]
        public BTInput_Move_Stance[] Stance { get; set; }

        [XmlArray(ElementName = "EndDistance")]
        [XmlArrayItem(Type = typeof(BTInputFloat))]
        [XmlArrayItem(Type = typeof(BTInputFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputFloatVar))]
        [XmlArrayItem(Type = typeof(BTInputFloatBB))]
        public BTInputFloat[] EndDistance { get; set; }

    }
}
