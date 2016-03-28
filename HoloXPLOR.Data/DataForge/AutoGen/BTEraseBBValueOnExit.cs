using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTEraseBBValueOnExit")]
    public partial class BTEraseBBValueOnExit : BTDecorator
    {
        [XmlArray(ElementName = "BTInput_Key")]
        [XmlArrayItem(Type = typeof(BTInputString))]
        [XmlArrayItem(Type = typeof(BTInputStringValue))]
        [XmlArrayItem(Type = typeof(BTInputStringVar))]
        [XmlArrayItem(Type = typeof(BTInputStringBB))]
        public BTInputString[] BTInput_Key { get; set; }

        [XmlArray(ElementName = "Blackboard")]
        [XmlArrayItem(Type = typeof(BTInputBlackboard))]
        [XmlArrayItem(Type = typeof(BTInputBlackboardVar))]
        [XmlArrayItem(Type = typeof(BTInputBlackboardBB))]
        public BTInputBlackboard[] Blackboard { get; set; }

    }
}
