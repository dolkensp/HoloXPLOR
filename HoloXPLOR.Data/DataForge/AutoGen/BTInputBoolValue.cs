using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInputBoolValue")]
    public partial class BTInputBoolValue : BTInputBool
    {
        [XmlAttribute(AttributeName = "value")]
        public Boolean Value { get; set; }

    }
}
