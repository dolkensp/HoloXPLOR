using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTTurnToFacePosition")]
    public partial class BTTurnToFacePosition : BTNode
    {
        [XmlArray(ElementName = "Position")]
        [XmlArrayItem(Type = typeof(BTInputPosition))]
        [XmlArrayItem(Type = typeof(BTInputPositionVar))]
        [XmlArrayItem(Type = typeof(BTInputPositionBB))]
        public BTInputPosition[] Position { get; set; }

    }
}
