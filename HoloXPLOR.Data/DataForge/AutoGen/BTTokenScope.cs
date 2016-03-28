using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTTokenScope")]
    public partial class BTTokenScope : BTDecorator
    {
        [XmlArray(ElementName = "TokenName")]
        [XmlArrayItem(Type = typeof(BTInputString))]
        [XmlArrayItem(Type = typeof(BTInputStringValue))]
        [XmlArrayItem(Type = typeof(BTInputStringVar))]
        [XmlArrayItem(Type = typeof(BTInputStringBB))]
        public BTInputString[] TokenName { get; set; }

        [XmlArray(ElementName = "MaxAllowed")]
        [XmlArrayItem(Type = typeof(BTInputInt))]
        [XmlArrayItem(Type = typeof(BTInputIntValue))]
        [XmlArrayItem(Type = typeof(BTInputIntVar))]
        [XmlArrayItem(Type = typeof(BTInputIntBB))]
        public BTInputInt[] MaxAllowed { get; set; }

    }
}
