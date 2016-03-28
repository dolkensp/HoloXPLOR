using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInputGenericIdVar")]
    public partial class BTInputGenericIdVar : BTInputGenericId
    {
        [XmlAttribute(AttributeName = "variableName")]
        public String VariableName { get; set; }

    }
}
