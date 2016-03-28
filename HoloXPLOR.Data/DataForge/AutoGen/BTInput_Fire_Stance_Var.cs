using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_Fire_Stance_Var")]
    public partial class BTInput_Fire_Stance_Var : BTInput_Fire_Stance
    {
        [XmlAttribute(AttributeName = "variableName")]
        public String VariableName { get; set; }

    }
}
