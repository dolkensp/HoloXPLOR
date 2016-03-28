using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTSendResponseSignal")]
    public partial class BTSendResponseSignal : BTNode
    {
        [XmlArray(ElementName = "Signal")]
        [XmlArrayItem(Type = typeof(BTInputBlackboard))]
        [XmlArrayItem(Type = typeof(BTInputBlackboardVar))]
        [XmlArrayItem(Type = typeof(BTInputBlackboardBB))]
        public BTInputBlackboard[] Signal { get; set; }

        [XmlArray(ElementName = "Result")]
        [XmlArrayItem(Type = typeof(BTInput_SendResponseSignal_Result))]
        [XmlArrayItem(Type = typeof(BTInput_SendResponseSignal_Result_String))]
        [XmlArrayItem(Type = typeof(BTInput_SendResponseSignal_Result_Var))]
        [XmlArrayItem(Type = typeof(BTInput_SendResponseSignal_Result_BB))]
        public BTInput_SendResponseSignal_Result[] Result { get; set; }

    }
}
