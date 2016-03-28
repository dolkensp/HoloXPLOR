using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_MoveAndAnimate_Destination_Var")]
    public partial class BTInput_MoveAndAnimate_Destination_Var : BTInput_MoveAndAnimate_Destination
    {
        [XmlAttribute(AttributeName = "variableName")]
        public String VariableName { get; set; }

    }
}
