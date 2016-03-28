using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTFindTakeOffSpline")]
    public partial class BTFindTakeOffSpline : BTNode
    {
        [XmlArray(ElementName = "AreaId")]
        [XmlArrayItem(Type = typeof(BTInputEntityId))]
        [XmlArrayItem(Type = typeof(BTInputEntityIdVar))]
        [XmlArrayItem(Type = typeof(BTInputEntityIdBB))]
        public BTInputEntityId[] AreaId { get; set; }

        [XmlArray(ElementName = "SplineId")]
        [XmlArrayItem(Type = typeof(BTOutput))]
        public BTOutput[] SplineId { get; set; }

    }
}
