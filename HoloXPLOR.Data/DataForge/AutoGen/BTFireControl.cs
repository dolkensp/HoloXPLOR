using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTFireControl")]
    public partial class BTFireControl : BTNode
    {
        [XmlArray(ElementName = "Enable")]
        [XmlArrayItem(Type = typeof(BTInputBool))]
        [XmlArrayItem(Type = typeof(BTInputBoolValue))]
        [XmlArrayItem(Type = typeof(BTInputBoolVar))]
        [XmlArrayItem(Type = typeof(BTInputBoolBB))]
        public BTInputBool[] Enable { get; set; }

    }
}
