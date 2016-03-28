using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_SetStance_Stance_String")]
    public partial class BTInput_SetStance_Stance_String : BTInput_SetStance_Stance
    {
        [XmlAttribute(AttributeName = "value")]
        public BehaviorTree_CharacterStance Value { get; set; }

    }
}
