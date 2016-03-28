using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTPopRandomArrayValue")]
    public partial class BTPopRandomArrayValue : BTNode
    {
        [XmlArray(ElementName = "Array")]
        [XmlArrayItem(Type = typeof(BTInputAny))]
        [XmlArrayItem(Type = typeof(BTInputAnyBoolValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyIntValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyStringValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyTagValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyVar))]
        [XmlArrayItem(Type = typeof(BTInputAnyBB))]
        public BTInputAny[] Array { get; set; }

        [XmlArray(ElementName = "Value")]
        [XmlArrayItem(Type = typeof(BTOutput))]
        public BTOutput[] Value { get; set; }

    }
}
