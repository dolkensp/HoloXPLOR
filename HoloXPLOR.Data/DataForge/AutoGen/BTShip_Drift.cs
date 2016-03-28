using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTShip_Drift")]
    public partial class BTShip_Drift : BTNode
    {
        [XmlArray(ElementName = "Look")]
        [XmlArrayItem(Type = typeof(BTInput_Ship_Drift_Look))]
        [XmlArrayItem(Type = typeof(BTInput_Ship_Drift_Look_Var))]
        [XmlArrayItem(Type = typeof(BTInput_Ship_Drift_Look_BB))]
        public BTInput_Ship_Drift_Look[] Look { get; set; }

    }
}
