using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInputStringValue")]
    public partial class BTInputStringValue : BTInputString
    {
        [XmlAttribute(AttributeName = "value")]
        public String Value { get; set; }

    }
}
