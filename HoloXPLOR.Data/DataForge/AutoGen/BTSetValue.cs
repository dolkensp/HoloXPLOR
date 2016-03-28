using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTSetValue")]
    public partial class BTSetValue : BTNode
    {
        [XmlArray(ElementName = "Input")]
        [XmlArrayItem(Type = typeof(BTInputAny))]
        [XmlArrayItem(Type = typeof(BTInputAnyBoolValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyIntValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyStringValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyTagValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyVar))]
        [XmlArrayItem(Type = typeof(BTInputAnyBB))]
        public BTInputAny[] Input { get; set; }

        [XmlArray(ElementName = "Output")]
        [XmlArrayItem(Type = typeof(BTOutput))]
        public BTOutput[] Output { get; set; }

    }
}
