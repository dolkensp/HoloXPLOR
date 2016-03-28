using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTSetVariable")]
    public partial class BTSetVariable : BTNode
    {
        [XmlArray(ElementName = "Name")]
        [XmlArrayItem(Type = typeof(BTInputString))]
        [XmlArrayItem(Type = typeof(BTInputStringValue))]
        [XmlArrayItem(Type = typeof(BTInputStringVar))]
        [XmlArrayItem(Type = typeof(BTInputStringBB))]
        public BTInputString[] Name { get; set; }

        [XmlArray(ElementName = "Value")]
        [XmlArrayItem(Type = typeof(BTInputAny))]
        [XmlArrayItem(Type = typeof(BTInputAnyBoolValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyIntValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyStringValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyTagValue))]
        [XmlArrayItem(Type = typeof(BTInputAnyVar))]
        [XmlArrayItem(Type = typeof(BTInputAnyBB))]
        public BTInputAny[] Value { get; set; }

    }
}
