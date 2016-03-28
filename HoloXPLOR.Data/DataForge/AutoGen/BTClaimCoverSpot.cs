using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTClaimCoverSpot")]
    public partial class BTClaimCoverSpot : BTNode
    {
        [XmlArray(ElementName = "CoverID")]
        [XmlArrayItem(Type = typeof(BTInputGenericId))]
        [XmlArrayItem(Type = typeof(BTInputGenericIdVar))]
        [XmlArrayItem(Type = typeof(BTInputGenericIdBB))]
        public BTInputGenericId[] CoverID { get; set; }

    }
}
