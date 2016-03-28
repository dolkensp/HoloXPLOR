using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInputAnyBoolValue")]
    public partial class BTInputAnyBoolValue : BTInputAny
    {
        [XmlAttribute(AttributeName = "value")]
        public Boolean Value { get; set; }

    }
}
