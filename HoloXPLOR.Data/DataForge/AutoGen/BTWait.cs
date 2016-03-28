using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTWait")]
    public partial class BTWait : BTNode
    {
        [XmlArray(ElementName = "WaitTime")]
        [XmlArrayItem(Type = typeof(BTInputFloat))]
        [XmlArrayItem(Type = typeof(BTInputFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputFloatVar))]
        [XmlArrayItem(Type = typeof(BTInputFloatBB))]
        public BTInputFloat[] WaitTime { get; set; }

    }
}
