using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTEraseBBValue")]
    public partial class BTEraseBBValue : BTNode
    {
        [XmlArray(ElementName = "Blackboard")]
        [XmlArrayItem(Type = typeof(BTInputBlackboard))]
        [XmlArrayItem(Type = typeof(BTInputBlackboardVar))]
        [XmlArrayItem(Type = typeof(BTInputBlackboardBB))]
        public BTInputBlackboard[] Blackboard { get; set; }

        [XmlArray(ElementName = "Name")]
        [XmlArrayItem(Type = typeof(BTInputString))]
        [XmlArrayItem(Type = typeof(BTInputStringValue))]
        [XmlArrayItem(Type = typeof(BTInputStringVar))]
        [XmlArrayItem(Type = typeof(BTInputStringBB))]
        public BTInputString[] Name { get; set; }

    }
}
