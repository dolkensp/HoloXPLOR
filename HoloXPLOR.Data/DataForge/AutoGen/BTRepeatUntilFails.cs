using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTRepeatUntilFails")]
    public partial class BTRepeatUntilFails : BTDecorator
    {
        [XmlArray(ElementName = "Iterations")]
        [XmlArrayItem(Type = typeof(BTInputInt))]
        [XmlArrayItem(Type = typeof(BTInputIntValue))]
        [XmlArrayItem(Type = typeof(BTInputIntVar))]
        [XmlArrayItem(Type = typeof(BTInputIntBB))]
        public BTInputInt[] Iterations { get; set; }

    }
}
