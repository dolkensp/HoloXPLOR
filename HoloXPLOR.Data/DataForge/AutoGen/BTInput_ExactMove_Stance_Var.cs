using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_ExactMove_Stance_Var")]
    public partial class BTInput_ExactMove_Stance_Var : BTInput_ExactMove_Stance
    {
        [XmlAttribute(AttributeName = "variableName")]
        public String VariableName { get; set; }

    }
}
