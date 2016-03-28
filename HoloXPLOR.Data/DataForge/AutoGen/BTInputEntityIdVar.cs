using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInputEntityIdVar")]
    public partial class BTInputEntityIdVar : BTInputEntityId
    {
        [XmlAttribute(AttributeName = "variableName")]
        public String VariableName { get; set; }

    }
}
