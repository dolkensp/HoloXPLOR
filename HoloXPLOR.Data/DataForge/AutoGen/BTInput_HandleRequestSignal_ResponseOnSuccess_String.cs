using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_HandleRequestSignal_ResponseOnSuccess_String")]
    public partial class BTInput_HandleRequestSignal_ResponseOnSuccess_String : BTInput_HandleRequestSignal_ResponseOnSuccess
    {
        [XmlAttribute(AttributeName = "value")]
        public BehaviorTree_SignalResponse Value { get; set; }

    }
}
