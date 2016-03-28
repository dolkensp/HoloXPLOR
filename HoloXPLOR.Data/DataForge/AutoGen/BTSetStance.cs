using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTSetStance")]
    public partial class BTSetStance : BTNode
    {
        [XmlArray(ElementName = "Stance")]
        [XmlArrayItem(Type = typeof(BTInput_SetStance_Stance))]
        [XmlArrayItem(Type = typeof(BTInput_SetStance_Stance_String))]
        [XmlArrayItem(Type = typeof(BTInput_SetStance_Stance_Var))]
        [XmlArrayItem(Type = typeof(BTInput_SetStance_Stance_BB))]
        public BTInput_SetStance_Stance[] Stance { get; set; }

        [XmlArray(ElementName = "Strafing")]
        [XmlArrayItem(Type = typeof(BTInputBool))]
        [XmlArrayItem(Type = typeof(BTInputBoolValue))]
        [XmlArrayItem(Type = typeof(BTInputBoolVar))]
        [XmlArrayItem(Type = typeof(BTInputBoolBB))]
        public BTInputBool[] Strafing { get; set; }

    }
}
