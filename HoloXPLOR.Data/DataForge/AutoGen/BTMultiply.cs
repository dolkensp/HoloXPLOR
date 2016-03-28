using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTMultiply")]
    public partial class BTMultiply : BTNode
    {
        [XmlArray(ElementName = "InputA")]
        [XmlArrayItem(Type = typeof(BTInputAny))]
        [XmlArrayItem(Type = typeof(BTInputAnyBoolValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyIntValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyStringValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyTagValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyVar))]
        [XmlArrayItem(Type = typeof(BTInputAnyBB))]
        public BTInputAny[] InputA { get; set; }

        [XmlArray(ElementName = "InputB")]
        [XmlArrayItem(Type = typeof(BTInputAny))]
        [XmlArrayItem(Type = typeof(BTInputAnyBoolValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyIntValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyStringValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyTagValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyVar))]
        [XmlArrayItem(Type = typeof(BTInputAnyBB))]
        public BTInputAny[] InputB { get; set; }

        [XmlArray(ElementName = "Result")]
        [XmlArrayItem(Type = typeof(BTOutput))]
        public BTOutput[] Result { get; set; }

    }
}
