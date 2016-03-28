using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInputTagValue")]
    public partial class BTInputTagValue : BTInputTag
    {
        [XmlAttribute(AttributeName = "value")]
        public String Value { get; set; }

    }
}
