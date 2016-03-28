using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInputValueOnlyFloat")]
    public partial class BTInputValueOnlyFloat : BTInputValueOnly
    {
        [XmlAttribute(AttributeName = "value")]
        public Single Value { get; set; }

    }
}
