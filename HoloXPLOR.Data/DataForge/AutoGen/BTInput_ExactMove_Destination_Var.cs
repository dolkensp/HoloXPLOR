using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_ExactMove_Destination_Var")]
    public partial class BTInput_ExactMove_Destination_Var : BTInput_ExactMove_Destination
    {
        [XmlAttribute(AttributeName = "variableName")]
        public String VariableName { get; set; }

    }
}
