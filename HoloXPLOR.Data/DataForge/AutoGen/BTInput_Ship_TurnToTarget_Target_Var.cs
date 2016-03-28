using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_Ship_TurnToTarget_Target_Var")]
    public partial class BTInput_Ship_TurnToTarget_Target_Var : BTInput_Ship_TurnToTarget_Target
    {
        [XmlAttribute(AttributeName = "variableName")]
        public String VariableName { get; set; }

    }
}
