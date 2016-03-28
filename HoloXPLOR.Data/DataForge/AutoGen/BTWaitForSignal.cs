using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTWaitForSignal")]
    public partial class BTWaitForSignal : BTNode
    {
        [XmlArray(ElementName = "Name")]
        [XmlArrayItem(Type = typeof(BTInputString))]
        [XmlArrayItem(Type = typeof(BTInputStringValue))]
        [XmlArrayItem(Type = typeof(BTInputStringVar))]
        [XmlArrayItem(Type = typeof(BTInputStringBB))]
        public BTInputString[] Name { get; set; }

        [XmlArray(ElementName = "FilterKey1")]
        [XmlArrayItem(Type = typeof(BTInputString))]
        [XmlArrayItem(Type = typeof(BTInputStringValue))]
        [XmlArrayItem(Type = typeof(BTInputStringVar))]
        [XmlArrayItem(Type = typeof(BTInputStringBB))]
        public BTInputString[] FilterKey1 { get; set; }

        [XmlArray(ElementName = "FilterValue1")]
        [XmlArrayItem(Type = typeof(BTInputAny))]
        [XmlArrayItem(Type = typeof(BTInputAnyBoolValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyIntValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyStringValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyTagValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyVar))]
        [XmlArrayItem(Type = typeof(BTInputAnyBB))]
        public BTInputAny[] FilterValue1 { get; set; }

        [XmlArray(ElementName = "FilterKey2")]
        [XmlArrayItem(Type = typeof(BTInputString))]
        [XmlArrayItem(Type = typeof(BTInputStringValue))]
        [XmlArrayItem(Type = typeof(BTInputStringVar))]
        [XmlArrayItem(Type = typeof(BTInputStringBB))]
        public BTInputString[] FilterKey2 { get; set; }

        [XmlArray(ElementName = "FilterValue2")]
        [XmlArrayItem(Type = typeof(BTInputAny))]
        [XmlArrayItem(Type = typeof(BTInputAnyBoolValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyIntValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyStringValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyTagValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyVar))]
        [XmlArrayItem(Type = typeof(BTInputAnyBB))]
        public BTInputAny[] FilterValue2 { get; set; }

        [XmlArray(ElementName = "Signal")]
        [XmlArrayItem(Type = typeof(BTOutput))]
        public BTOutput[] Signal { get; set; }

    }
}
