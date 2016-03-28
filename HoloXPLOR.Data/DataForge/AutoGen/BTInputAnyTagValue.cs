using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInputAnyTagValue")]
    public partial class BTInputAnyTagValue : BTInputAny
    {
        [XmlAttribute(AttributeName = "value")]
        public String Value { get; set; }

    }
}
