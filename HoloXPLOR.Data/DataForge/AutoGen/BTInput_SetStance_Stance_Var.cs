using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_SetStance_Stance_Var")]
    public partial class BTInput_SetStance_Stance_Var : BTInput_SetStance_Stance
    {
        [XmlAttribute(AttributeName = "variableName")]
        public String VariableName { get; set; }

    }
}
