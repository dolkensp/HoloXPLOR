using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_SendSignalToGroup_Name_Var")]
    public partial class BTInput_SendSignalToGroup_Name_Var : BTInput_SendSignalToGroup_Name
    {
        [XmlAttribute(AttributeName = "variableName")]
        public String VariableName { get; set; }

    }
}
