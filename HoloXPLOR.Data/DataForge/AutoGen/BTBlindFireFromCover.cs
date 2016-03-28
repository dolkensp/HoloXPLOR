using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTBlindFireFromCover")]
    public partial class BTBlindFireFromCover : BTNode
    {
        [XmlArray(ElementName = "TimeDurationInSeconds")]
        [XmlArrayItem(Type = typeof(BTInputFloat))]
        [XmlArrayItem(Type = typeof(BTInputFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputFloatVar))]
        [XmlArrayItem(Type = typeof(BTInputFloatBB))]
        public BTInputFloat[] TimeDurationInSeconds { get; set; }

    }
}
