using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInputAnyStringValue")]
    public partial class BTInputAnyStringValue : BTInputAny
    {
        [XmlAttribute(AttributeName = "value")]
        public String Value { get; set; }

    }
}
