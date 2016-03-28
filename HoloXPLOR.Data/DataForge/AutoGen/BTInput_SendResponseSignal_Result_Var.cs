using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_SendResponseSignal_Result_Var")]
    public partial class BTInput_SendResponseSignal_Result_Var : BTInput_SendResponseSignal_Result
    {
        [XmlAttribute(AttributeName = "variableName")]
        public String VariableName { get; set; }

    }
}
