using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTFire")]
    public partial class BTFire : BTNode
    {
        [XmlArray(ElementName = "DurationTime")]
        [XmlArrayItem(Type = typeof(BTInputFloat))]
        [XmlArrayItem(Type = typeof(BTInputFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputFloatVar))]
        [XmlArrayItem(Type = typeof(BTInputFloatBB))]
        public BTInputFloat[] DurationTime { get; set; }

        [XmlArray(ElementName = "Stance")]
        [XmlArrayItem(Type = typeof(BTInput_Fire_Stance))]
        [XmlArrayItem(Type = typeof(BTInput_Fire_Stance_String))]
        [XmlArrayItem(Type = typeof(BTInput_Fire_Stance_Var))]
        [XmlArrayItem(Type = typeof(BTInput_Fire_Stance_BB))]
        public BTInput_Fire_Stance[] Stance { get; set; }

    }
}
