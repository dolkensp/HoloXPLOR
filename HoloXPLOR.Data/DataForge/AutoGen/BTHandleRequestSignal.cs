using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTHandleRequestSignal")]
    public partial class BTHandleRequestSignal : BTDecorator
    {
        [XmlArray(ElementName = "Signal")]
        [XmlArrayItem(Type = typeof(BTInputBlackboard))]
        [XmlArrayItem(Type = typeof(BTInputBlackboardVar))]
        [XmlArrayItem(Type = typeof(BTInputBlackboardBB))]
        public BTInputBlackboard[] Signal { get; set; }

        [XmlArray(ElementName = "ResponseOnSuccess")]
        [XmlArrayItem(Type = typeof(BTInput_HandleRequestSignal_ResponseOnSuccess))]
        [XmlArrayItem(Type = typeof(BTInput_HandleRequestSignal_ResponseOnSuccess_String))]
        [XmlArrayItem(Type = typeof(BTInput_HandleRequestSignal_ResponseOnSuccess_Var))]
        [XmlArrayItem(Type = typeof(BTInput_HandleRequestSignal_ResponseOnSuccess_BB))]
        public BTInput_HandleRequestSignal_ResponseOnSuccess[] ResponseOnSuccess { get; set; }

        [XmlArray(ElementName = "ResponseOnFail")]
        [XmlArrayItem(Type = typeof(BTInput_HandleRequestSignal_ResponseOnFail))]
        [XmlArrayItem(Type = typeof(BTInput_HandleRequestSignal_ResponseOnFail_String))]
        [XmlArrayItem(Type = typeof(BTInput_HandleRequestSignal_ResponseOnFail_Var))]
        [XmlArrayItem(Type = typeof(BTInput_HandleRequestSignal_ResponseOnFail_BB))]
        public BTInput_HandleRequestSignal_ResponseOnFail[] ResponseOnFail { get; set; }

        [XmlArray(ElementName = "ResponseOnEnter")]
        [XmlArrayItem(Type = typeof(BTInput_HandleRequestSignal_ResponseOnEnter))]
        [XmlArrayItem(Type = typeof(BTInput_HandleRequestSignal_ResponseOnEnter_String))]
        [XmlArrayItem(Type = typeof(BTInput_HandleRequestSignal_ResponseOnEnter_Var))]
        [XmlArrayItem(Type = typeof(BTInput_HandleRequestSignal_ResponseOnEnter_BB))]
        public BTInput_HandleRequestSignal_ResponseOnEnter[] ResponseOnEnter { get; set; }

    }
}
