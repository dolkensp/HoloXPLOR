using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTCommunicate")]
    public partial class BTCommunicate : BTNode
    {
        [XmlArray(ElementName = "CommName")]
        [XmlArrayItem(Type = typeof(BTInputString))]
        [XmlArrayItem(Type = typeof(BTInputStringValue))]
        [XmlArrayItem(Type = typeof(BTInputStringVar))]
        [XmlArrayItem(Type = typeof(BTInputStringBB))]
        public BTInputString[] CommName { get; set; }

        [XmlArray(ElementName = "ChannelName")]
        [XmlArrayItem(Type = typeof(BTInputString))]
        [XmlArrayItem(Type = typeof(BTInputStringValue))]
        [XmlArrayItem(Type = typeof(BTInputStringVar))]
        [XmlArrayItem(Type = typeof(BTInputStringBB))]
        public BTInputString[] ChannelName { get; set; }

        [XmlArray(ElementName = "ExpirationTime")]
        [XmlArrayItem(Type = typeof(BTInputFloat))]
        [XmlArrayItem(Type = typeof(BTInputFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputFloatVar))]
        [XmlArrayItem(Type = typeof(BTInputFloatBB))]
        public BTInputFloat[] ExpirationTime { get; set; }

        [XmlArray(ElementName = "WaitUntilFinished")]
        [XmlArrayItem(Type = typeof(BTInputBool))]
        [XmlArrayItem(Type = typeof(BTInputBoolValue))]
        [XmlArrayItem(Type = typeof(BTInputBoolVar))]
        [XmlArrayItem(Type = typeof(BTInputBoolBB))]
        public BTInputBool[] WaitUntilFinished { get; set; }

    }
}
