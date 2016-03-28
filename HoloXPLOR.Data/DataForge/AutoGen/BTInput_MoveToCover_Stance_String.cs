using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_MoveToCover_Stance_String")]
    public partial class BTInput_MoveToCover_Stance_String : BTInput_MoveToCover_Stance
    {
        [XmlAttribute(AttributeName = "value")]
        public BehaviorTree_CharacterStance Value { get; set; }

    }
}
