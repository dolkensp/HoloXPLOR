using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_Ship_Drift_Look_Var")]
    public partial class BTInput_Ship_Drift_Look_Var : BTInput_Ship_Drift_Look
    {
        [XmlAttribute(AttributeName = "variableName")]
        public String VariableName { get; set; }

    }
}
