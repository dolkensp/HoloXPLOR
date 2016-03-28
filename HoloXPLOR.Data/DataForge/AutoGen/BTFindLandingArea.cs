using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTFindLandingArea")]
    public partial class BTFindLandingArea : BTNode
    {
        [XmlArray(ElementName = "PreferredArea")]
        [XmlArrayItem(Type = typeof(BTInputEntityId))]
        [XmlArrayItem(Type = typeof(BTInputEntityIdVar))]
        [XmlArrayItem(Type = typeof(BTInputEntityIdBB))]
        public BTInputEntityId[] PreferredArea { get; set; }

        [XmlArray(ElementName = "Filter")]
        [XmlArrayItem(Type = typeof(BTInputString))]
        [XmlArrayItem(Type = typeof(BTInputStringValue))]
        [XmlArrayItem(Type = typeof(BTInputStringVar))]
        [XmlArrayItem(Type = typeof(BTInputStringBB))]
        public BTInputString[] Filter { get; set; }

        [XmlArray(ElementName = "OnlyUsePreferredIfProvided")]
        [XmlArrayItem(Type = typeof(BTInputBool))]
        [XmlArrayItem(Type = typeof(BTInputBoolValue))]
        [XmlArrayItem(Type = typeof(BTInputBoolVar))]
        [XmlArrayItem(Type = typeof(BTInputBoolBB))]
        public BTInputBool[] OnlyUsePreferredIfProvided { get; set; }

        [XmlArray(ElementName = "AreaId")]
        [XmlArrayItem(Type = typeof(BTOutput))]
        public BTOutput[] AreaId { get; set; }

    }
}
