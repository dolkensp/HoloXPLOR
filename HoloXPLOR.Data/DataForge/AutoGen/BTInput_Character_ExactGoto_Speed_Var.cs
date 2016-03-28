using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_Character_ExactGoto_Speed_Var")]
    public partial class BTInput_Character_ExactGoto_Speed_Var : BTInput_Character_ExactGoto_Speed
    {
        [XmlAttribute(AttributeName = "variableName")]
        public String VariableName { get; set; }

    }
}
