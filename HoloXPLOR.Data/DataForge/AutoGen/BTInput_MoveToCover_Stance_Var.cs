using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_MoveToCover_Stance_Var")]
    public partial class BTInput_MoveToCover_Stance_Var : BTInput_MoveToCover_Stance
    {
        [XmlAttribute(AttributeName = "variableName")]
        public String VariableName { get; set; }

    }
}
