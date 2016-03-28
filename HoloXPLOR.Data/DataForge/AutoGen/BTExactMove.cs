using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTExactMove")]
    public partial class BTExactMove : BTNode
    {
        [XmlArray(ElementName = "Destination")]
        [XmlArrayItem(Type = typeof(BTInput_ExactMove_Destination))]
        [XmlArrayItem(Type = typeof(BTInput_ExactMove_Destination_Var))]
        [XmlArrayItem(Type = typeof(BTInput_ExactMove_Destination_BB))]
        public BTInput_ExactMove_Destination[] Destination { get; set; }

        [XmlArray(ElementName = "Direction")]
        [XmlArrayItem(Type = typeof(BTInputVec3))]
        [XmlArrayItem(Type = typeof(BTInputVec3Var))]
        [XmlArrayItem(Type = typeof(BTInputVec3BB))]
        public BTInputVec3[] Direction { get; set; }

        [XmlArray(ElementName = "Speed")]
        [XmlArrayItem(Type = typeof(BTInput_ExactMove_Speed))]
        [XmlArrayItem(Type = typeof(BTInput_ExactMove_Speed_String))]
        [XmlArrayItem(Type = typeof(BTInput_ExactMove_Speed_Var))]
        [XmlArrayItem(Type = typeof(BTInput_ExactMove_Speed_BB))]
        public BTInput_ExactMove_Speed[] Speed { get; set; }

        [XmlArray(ElementName = "Stance")]
        [XmlArrayItem(Type = typeof(BTInput_ExactMove_Stance))]
        [XmlArrayItem(Type = typeof(BTInput_ExactMove_Stance_String))]
        [XmlArrayItem(Type = typeof(BTInput_ExactMove_Stance_Var))]
        [XmlArrayItem(Type = typeof(BTInput_ExactMove_Stance_BB))]
        public BTInput_ExactMove_Stance[] Stance { get; set; }

    }
}
