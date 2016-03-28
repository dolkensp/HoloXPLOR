using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTShip_TrackEntity")]
    public partial class BTShip_TrackEntity : BTNode
    {
        [XmlArray(ElementName = "Target")]
        [XmlArrayItem(Type = typeof(BTInput_Ship_TrackEntity_Target))]
        [XmlArrayItem(Type = typeof(BTInput_Ship_TrackEntity_Target_Var))]
        [XmlArrayItem(Type = typeof(BTInput_Ship_TrackEntity_Target_BB))]
        public BTInput_Ship_TrackEntity_Target[] Target { get; set; }

        [XmlArray(ElementName = "MinAbsoluteSpeed")]
        [XmlArrayItem(Type = typeof(BTInputFloat))]
        [XmlArrayItem(Type = typeof(BTInputFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputFloatVar))]
        [XmlArrayItem(Type = typeof(BTInputFloatBB))]
        public BTInputFloat[] MinAbsoluteSpeed { get; set; }

        [XmlArray(ElementName = "MinRelativeSpeed")]
        [XmlArrayItem(Type = typeof(BTInputFloat))]
        [XmlArrayItem(Type = typeof(BTInputFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputFloatVar))]
        [XmlArrayItem(Type = typeof(BTInputFloatBB))]
        public BTInputFloat[] MinRelativeSpeed { get; set; }

        [XmlArray(ElementName = "MaxAbsoluteSpeed")]
        [XmlArrayItem(Type = typeof(BTInputFloat))]
        [XmlArrayItem(Type = typeof(BTInputFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputFloatVar))]
        [XmlArrayItem(Type = typeof(BTInputFloatBB))]
        public BTInputFloat[] MaxAbsoluteSpeed { get; set; }

        [XmlArray(ElementName = "MaxRelativeSpeed")]
        [XmlArrayItem(Type = typeof(BTInputFloat))]
        [XmlArrayItem(Type = typeof(BTInputFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputFloatVar))]
        [XmlArrayItem(Type = typeof(BTInputFloatBB))]
        public BTInputFloat[] MaxRelativeSpeed { get; set; }

        [XmlArray(ElementName = "Distance")]
        [XmlArrayItem(Type = typeof(BTInputFloat))]
        [XmlArrayItem(Type = typeof(BTInputFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputFloatVar))]
        [XmlArrayItem(Type = typeof(BTInputFloatBB))]
        public BTInputFloat[] Distance { get; set; }

    }
}
