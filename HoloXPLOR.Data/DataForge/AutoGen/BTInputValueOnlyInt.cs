using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInputValueOnlyInt")]
    public partial class BTInputValueOnlyInt : BTInputValueOnly
    {
        [XmlAttribute(AttributeName = "value")]
        public Int32 Value { get; set; }

    }
}
