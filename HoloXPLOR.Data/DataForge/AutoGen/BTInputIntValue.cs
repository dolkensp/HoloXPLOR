using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInputIntValue")]
    public partial class BTInputIntValue : BTInputInt
    {
        [XmlAttribute(AttributeName = "value")]
        public Int32 Value { get; set; }

    }
}
