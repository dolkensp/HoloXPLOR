using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTGetSignalParameter")]
    public partial class BTGetSignalParameter : BTNode
    {
        [XmlArray(ElementName = "Signal")]
        [XmlArrayItem(Type = typeof(BTInputBlackboard))]
        [XmlArrayItem(Type = typeof(BTInputBlackboardVar))]
        [XmlArrayItem(Type = typeof(BTInputBlackboardBB))]
        public BTInputBlackboard[] Signal { get; set; }

        [XmlArray(ElementName = "ParameterName")]
        [XmlArrayItem(Type = typeof(BTInputString))]
        [XmlArrayItem(Type = typeof(BTInputStringValue))]
        [XmlArrayItem(Type = typeof(BTInputStringVar))]
        [XmlArrayItem(Type = typeof(BTInputStringBB))]
        public BTInputString[] ParameterName { get; set; }

        [XmlArray(ElementName = "Value")]
        [XmlArrayItem(Type = typeof(BTOutput))]
        public BTOutput[] Value { get; set; }

    }
}
