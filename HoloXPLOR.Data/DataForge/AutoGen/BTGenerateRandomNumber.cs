using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTGenerateRandomNumber")]
    public partial class BTGenerateRandomNumber : BTNode
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

        [XmlArray(ElementName = "Scale")]
        [XmlArrayItem(Type = typeof(BTInputFloat))]
        [XmlArrayItem(Type = typeof(BTInputFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputFloatVar))]
        [XmlArrayItem(Type = typeof(BTInputFloatBB))]
        public BTInputFloat[] Scale { get; set; }

        [XmlArray(ElementName = "Result")]
        [XmlArrayItem(Type = typeof(BTOutput))]
        public BTOutput[] Result { get; set; }

    }
}
