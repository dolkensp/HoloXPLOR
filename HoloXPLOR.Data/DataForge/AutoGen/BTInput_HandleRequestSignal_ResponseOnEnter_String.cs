using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_HandleRequestSignal_ResponseOnEnter_String")]
    public partial class BTInput_HandleRequestSignal_ResponseOnEnter_String : BTInput_HandleRequestSignal_ResponseOnEnter
    {
        [XmlAttribute(AttributeName = "value")]
        public BehaviorTree_SignalResponse Value { get; set; }

    }
}
