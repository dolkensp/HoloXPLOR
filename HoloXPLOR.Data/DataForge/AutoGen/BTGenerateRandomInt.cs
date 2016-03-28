using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTGenerateRandomInt")]
    public partial class BTGenerateRandomInt : BTNode
    {
        [XmlArray(ElementName = "MinVal")]
        [XmlArrayItem(Type = typeof(BTInputInt))]
        [XmlArrayItem(Type = typeof(BTInputIntValue))]
        [XmlArrayItem(Type = typeof(BTInputIntVar))]
        [XmlArrayItem(Type = typeof(BTInputIntBB))]
        public BTInputInt[] MinVal { get; set; }

        [XmlArray(ElementName = "MaxVal")]
        [XmlArrayItem(Type = typeof(BTInputInt))]
        [XmlArrayItem(Type = typeof(BTInputIntValue))]
        [XmlArrayItem(Type = typeof(BTInputIntVar))]
        [XmlArrayItem(Type = typeof(BTInputIntBB))]
        public BTInputInt[] MaxVal { get; set; }

        [XmlArray(ElementName = "Result")]
        [XmlArrayItem(Type = typeof(BTOutput))]
        public BTOutput[] Result { get; set; }

    }
}
