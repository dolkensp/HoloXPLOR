using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_Ship_TrackEntity_Target_Var")]
    public partial class BTInput_Ship_TrackEntity_Target_Var : BTInput_Ship_TrackEntity_Target
    {
        [XmlAttribute(AttributeName = "variableName")]
        public String VariableName { get; set; }

    }
}
