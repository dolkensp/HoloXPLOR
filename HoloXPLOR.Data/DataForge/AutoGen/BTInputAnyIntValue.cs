using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInputAnyIntValue")]
    public partial class BTInputAnyIntValue : BTInputAny
    {
        [XmlAttribute(AttributeName = "value")]
        public Int32 Value { get; set; }

    }
}
