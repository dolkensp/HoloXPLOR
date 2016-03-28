using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTShip_MaintainVel")]
    public partial class BTShip_MaintainVel : BTNode
    {
        [XmlArray(ElementName = "Velocity")]
        [XmlArrayItem(Type = typeof(BTInputVelocity))]
        [XmlArrayItem(Type = typeof(BTInputVelocityVar))]
        [XmlArrayItem(Type = typeof(BTInputVelocityBB))]
        public BTInputVelocity[] Velocity { get; set; }

        [XmlArray(ElementName = "Look")]
        [XmlArrayItem(Type = typeof(BTInput_Ship_MaintainVel_Look))]
        [XmlArrayItem(Type = typeof(BTInput_Ship_MaintainVel_Look_Var))]
        [XmlArrayItem(Type = typeof(BTInput_Ship_MaintainVel_Look_BB))]
        public BTInput_Ship_MaintainVel_Look[] Look { get; set; }

    }
}
