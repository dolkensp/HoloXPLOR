using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTCompute")]
    public partial class BTCompute : BTNode
    {
        [XmlArray(ElementName = "Expression")]
        [XmlArrayItem(Type = typeof(BTInputString))]
        [XmlArrayItem(Type = typeof(BTInputStringValue))]
        [XmlArrayItem(Type = typeof(BTInputStringVar))]
        [XmlArrayItem(Type = typeof(BTInputStringBB))]
        public BTInputString[] Expression { get; set; }

        [XmlArray(ElementName = "Result")]
        [XmlArrayItem(Type = typeof(BTOutput))]
        public BTOutput[] Result { get; set; }

    }
}
