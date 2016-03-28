using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_Move_Stance_String")]
    public partial class BTInput_Move_Stance_String : BTInput_Move_Stance
    {
        [XmlAttribute(AttributeName = "value")]
        public BehaviorTree_CharacterStance Value { get; set; }

    }
}
