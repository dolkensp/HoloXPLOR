using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInputValueOnlyString")]
    public partial class BTInputValueOnlyString : BTInputValueOnly
    {
        [XmlAttribute(AttributeName = "value")]
        public String Value { get; set; }

    }
}
