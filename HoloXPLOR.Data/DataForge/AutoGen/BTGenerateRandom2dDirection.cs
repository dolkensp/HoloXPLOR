using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTGenerateRandom2dDirection")]
    public partial class BTGenerateRandom2dDirection : BTNode
    {
        [XmlArray(ElementName = "Forward")]
        [XmlArrayItem(Type = typeof(BTInputVec3))]
        [XmlArrayItem(Type = typeof(BTInputVec3Var))]
        [XmlArrayItem(Type = typeof(BTInputVec3BB))]
        public BTInputVec3[] Forward { get; set; }

        [XmlArray(ElementName = "Angle")]
        [XmlArrayItem(Type = typeof(BTInputFloat))]
        [XmlArrayItem(Type = typeof(BTInputFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputFloatVar))]
        [XmlArrayItem(Type = typeof(BTInputFloatBB))]
        public BTInputFloat[] Angle { get; set; }

        [XmlArray(ElementName = "Direction")]
        [XmlArrayItem(Type = typeof(BTOutput))]
        public BTOutput[] Direction { get; set; }

    }
}
