using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTPeekFromCover")]
    public partial class BTPeekFromCover : BTNode
    {
        [XmlArray(ElementName = "TimeDurationInSeconds")]
        [XmlArrayItem(Type = typeof(BTInputFloat))]
        [XmlArrayItem(Type = typeof(BTInputFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputFloatVar))]
        [XmlArrayItem(Type = typeof(BTInputFloatBB))]
        public BTInputFloat[] TimeDurationInSeconds { get; set; }

    }
}
