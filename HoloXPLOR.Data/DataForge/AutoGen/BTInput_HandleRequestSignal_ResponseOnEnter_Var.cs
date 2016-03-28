using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_HandleRequestSignal_ResponseOnEnter_Var")]
    public partial class BTInput_HandleRequestSignal_ResponseOnEnter_Var : BTInput_HandleRequestSignal_ResponseOnEnter
    {
        [XmlAttribute(AttributeName = "variableName")]
        public String VariableName { get; set; }

    }
}
