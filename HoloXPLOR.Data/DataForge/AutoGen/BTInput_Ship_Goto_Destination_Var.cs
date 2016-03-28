using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_Ship_Goto_Destination_Var")]
    public partial class BTInput_Ship_Goto_Destination_Var : BTInput_Ship_Goto_Destination
    {
        [XmlAttribute(AttributeName = "variableName")]
        public String VariableName { get; set; }

    }
}
