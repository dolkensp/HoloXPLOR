using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTScreenMessage")]
    public partial class BTScreenMessage : BTNode
    {
        [XmlArray(ElementName = "Message")]
        [XmlArrayItem(Type = typeof(BTInputString))]
        [XmlArrayItem(Type = typeof(BTInputStringValue))]
        [XmlArrayItem(Type = typeof(BTInputStringVar))]
        [XmlArrayItem(Type = typeof(BTInputStringBB))]
        public BTInputString[] Message { get; set; }

        [XmlArray(ElementName = "TimeDurationInSeconds")]
        [XmlArrayItem(Type = typeof(BTInputFloat))]
        [XmlArrayItem(Type = typeof(BTInputFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputFloatVar))]
        [XmlArrayItem(Type = typeof(BTInputFloatBB))]
        public BTInputFloat[] TimeDurationInSeconds { get; set; }

        [XmlArray(ElementName = "Blocking")]
        [XmlArrayItem(Type = typeof(BTInputBool))]
        [XmlArrayItem(Type = typeof(BTInputBoolValue))]
        [XmlArrayItem(Type = typeof(BTInputBoolVar))]
        [XmlArrayItem(Type = typeof(BTInputBoolBB))]
        public BTInputBool[] Blocking { get; set; }

    }
}
