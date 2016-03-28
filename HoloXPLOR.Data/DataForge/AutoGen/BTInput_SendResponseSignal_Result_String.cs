using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_SendResponseSignal_Result_String")]
    public partial class BTInput_SendResponseSignal_Result_String : BTInput_SendResponseSignal_Result
    {
        [XmlAttribute(AttributeName = "value")]
        public BehaviorTree_SignalResponse Value { get; set; }

    }
}
