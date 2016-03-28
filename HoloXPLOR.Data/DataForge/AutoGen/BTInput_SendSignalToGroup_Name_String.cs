using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_SendSignalToGroup_Name_String")]
    public partial class BTInput_SendSignalToGroup_Name_String : BTInput_SendSignalToGroup_Name
    {
        [XmlAttribute(AttributeName = "value")]
        public BehaviorTree_GroupSignal Value { get; set; }

    }
}
