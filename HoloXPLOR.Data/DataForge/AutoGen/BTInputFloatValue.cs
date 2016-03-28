using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInputFloatValue")]
    public partial class BTInputFloatValue : BTInputFloat
    {
        [XmlAttribute(AttributeName = "value")]
        public Single Value { get; set; }

    }
}
