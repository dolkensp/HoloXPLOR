using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTShip_WithAvoidanceMode")]
    public partial class BTShip_WithAvoidanceMode : BTDecorator
    {
        [XmlArray(ElementName = "Enable")]
        [XmlArrayItem(Type = typeof(BTInputBool))]
        [XmlArrayItem(Type = typeof(BTInputBoolValue))]
        [XmlArrayItem(Type = typeof(BTInputBoolVar))]
        [XmlArrayItem(Type = typeof(BTInputBoolBB))]
        public BTInputBool[] Enable { get; set; }

    }
}
