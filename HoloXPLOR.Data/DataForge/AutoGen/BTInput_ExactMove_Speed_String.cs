using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_ExactMove_Speed_String")]
    public partial class BTInput_ExactMove_Speed_String : BTInput_ExactMove_Speed
    {
        [XmlAttribute(AttributeName = "value")]
        public BehaviorTree_CharacterSpeed Value { get; set; }

    }
}
