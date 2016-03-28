using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInputValueOnlyBool")]
    public partial class BTInputValueOnlyBool : BTInputValueOnly
    {
        [XmlAttribute(AttributeName = "value")]
        public Boolean Value { get; set; }

    }
}
