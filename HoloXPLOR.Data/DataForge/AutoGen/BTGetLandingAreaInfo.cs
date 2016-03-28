using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTGetLandingAreaInfo")]
    public partial class BTGetLandingAreaInfo : BTNode
    {
        [XmlArray(ElementName = "AreaId")]
        [XmlArrayItem(Type = typeof(BTInputEntityId))]
        [XmlArrayItem(Type = typeof(BTInputEntityIdVar))]
        [XmlArrayItem(Type = typeof(BTInputEntityIdBB))]
        public BTInputEntityId[] AreaId { get; set; }

        [XmlArray(ElementName = "Align")]
        [XmlArrayItem(Type = typeof(BTOutput))]
        public BTOutput[] Align { get; set; }

        [XmlArray(ElementName = "Normal")]
        [XmlArrayItem(Type = typeof(BTOutput))]
        public BTOutput[] Normal { get; set; }

        [XmlArray(ElementName = "Forward")]
        [XmlArrayItem(Type = typeof(BTOutput))]
        public BTOutput[] Forward { get; set; }

        [XmlArray(ElementName = "ApproachDistance")]
        [XmlArrayItem(Type = typeof(BTOutput))]
        public BTOutput[] ApproachDistance { get; set; }

    }
}
