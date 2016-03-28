using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTShip_Goto")]
    public partial class BTShip_Goto : BTNode
    {
        [XmlArray(ElementName = "Destination")]
        [XmlArrayItem(Type = typeof(BTInput_Ship_Goto_Destination))]
        [XmlArrayItem(Type = typeof(BTInput_Ship_Goto_Destination_Var))]
        [XmlArrayItem(Type = typeof(BTInput_Ship_Goto_Destination_BB))]
        public BTInput_Ship_Goto_Destination[] Destination { get; set; }

        [XmlArray(ElementName = "AbsoluteSpeed")]
        [XmlArrayItem(Type = typeof(BTInputFloat))]
        [XmlArrayItem(Type = typeof(BTInputFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputFloatVar))]
        [XmlArrayItem(Type = typeof(BTInputFloatBB))]
        public BTInputFloat[] AbsoluteSpeed { get; set; }

        [XmlArray(ElementName = "RelativeSpeed")]
        [XmlArrayItem(Type = typeof(BTInputFloat))]
        [XmlArrayItem(Type = typeof(BTInputFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputFloatVar))]
        [XmlArrayItem(Type = typeof(BTInputFloatBB))]
        public BTInputFloat[] RelativeSpeed { get; set; }

        [XmlArray(ElementName = "EndDistance")]
        [XmlArrayItem(Type = typeof(BTInputFloat))]
        [XmlArrayItem(Type = typeof(BTInputFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputFloatVar))]
        [XmlArrayItem(Type = typeof(BTInputFloatBB))]
        public BTInputFloat[] EndDistance { get; set; }

        [XmlArray(ElementName = "AbsoluteSpeedAtDestination")]
        [XmlArrayItem(Type = typeof(BTInputFloat))]
        [XmlArrayItem(Type = typeof(BTInputFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputFloatVar))]
        [XmlArrayItem(Type = typeof(BTInputFloatBB))]
        public BTInputFloat[] AbsoluteSpeedAtDestination { get; set; }

    }
}
