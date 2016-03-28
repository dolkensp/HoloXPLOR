using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_SendSignalToGroup_Category_String")]
    public partial class BTInput_SendSignalToGroup_Category_String : BTInput_SendSignalToGroup_Category
    {
        [XmlAttribute(AttributeName = "value")]
        public BehaviorTree_GroupCategory Value { get; set; }

    }
}
