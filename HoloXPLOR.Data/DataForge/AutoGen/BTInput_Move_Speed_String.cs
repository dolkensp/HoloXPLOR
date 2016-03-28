using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_Move_Speed_String")]
    public partial class BTInput_Move_Speed_String : BTInput_Move_Speed
    {
        [XmlAttribute(AttributeName = "value")]
        public BehaviorTree_CharacterSpeed Value { get; set; }

    }
}
