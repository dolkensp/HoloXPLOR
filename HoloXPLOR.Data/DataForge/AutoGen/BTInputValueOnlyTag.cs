using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInputValueOnlyTag")]
    public partial class BTInputValueOnlyTag : BTInputValueOnly
    {
        [XmlAttribute(AttributeName = "value")]
        public String Value { get; set; }

    }
}
