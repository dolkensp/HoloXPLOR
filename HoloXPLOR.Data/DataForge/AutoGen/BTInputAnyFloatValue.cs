using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInputAnyFloatValue")]
    public partial class BTInputAnyFloatValue : BTInputAny
    {
        [XmlAttribute(AttributeName = "value")]
        public Single Value { get; set; }

    }
}
