using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTPlayCharacterAnimation")]
    public partial class BTPlayCharacterAnimation : BTNode
    {
        [XmlArray(ElementName = "Position")]
        [XmlArrayItem(Type = typeof(BTInputPosition))]
        [XmlArrayItem(Type = typeof(BTInputPositionVar))]
        [XmlArrayItem(Type = typeof(BTInputPositionBB))]
        public BTInputPosition[] Position { get; set; }

        [XmlArray(ElementName = "Direction")]
        [XmlArrayItem(Type = typeof(BTInputVec3))]
        [XmlArrayItem(Type = typeof(BTInputVec3Var))]
        [XmlArrayItem(Type = typeof(BTInputVec3BB))]
        public BTInputVec3[] Direction { get; set; }

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

    }
}
