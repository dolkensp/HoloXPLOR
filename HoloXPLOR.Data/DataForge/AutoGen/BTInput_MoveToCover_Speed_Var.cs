using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_MoveToCover_Speed_Var")]
    public partial class BTInput_MoveToCover_Speed_Var : BTInput_MoveToCover_Speed
    {
        [XmlAttribute(AttributeName = "variableName")]
        public String VariableName { get; set; }

    }
}
