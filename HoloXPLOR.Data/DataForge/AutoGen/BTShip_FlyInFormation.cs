using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTShip_FlyInFormation")]
    public partial class BTShip_FlyInFormation : BTNode
    {
        [XmlArray(ElementName = "Formation")]
        [XmlArrayItem(Type = typeof(BTInputEntityId))]
        [XmlArrayItem(Type = typeof(BTInputEntityIdVar))]
        [XmlArrayItem(Type = typeof(BTInputEntityIdBB))]
        public BTInputEntityId[] Formation { get; set; }

    }
}
