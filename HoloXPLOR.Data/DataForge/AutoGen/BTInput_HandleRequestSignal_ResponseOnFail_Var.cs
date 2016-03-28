using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_HandleRequestSignal_ResponseOnFail_Var")]
    public partial class BTInput_HandleRequestSignal_ResponseOnFail_Var : BTInput_HandleRequestSignal_ResponseOnFail
    {
        [XmlAttribute(AttributeName = "variableName")]
        public String VariableName { get; set; }

    }
}
