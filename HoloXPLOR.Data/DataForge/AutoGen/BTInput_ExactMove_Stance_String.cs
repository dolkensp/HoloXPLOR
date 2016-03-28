using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_ExactMove_Stance_String")]
    public partial class BTInput_ExactMove_Stance_String : BTInput_ExactMove_Stance
    {
        [XmlAttribute(AttributeName = "value")]
        public BehaviorTree_CharacterStance Value { get; set; }

    }
}
