using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTCreateEntity")]
    public partial class BTCreateEntity : BTNode
    {
        [XmlArray(ElementName = "EntityClass")]
        [XmlArrayItem(Type = typeof(BTInputString))]
        [XmlArrayItem(Type = typeof(BTInputStringValue))]
        [XmlArrayItem(Type = typeof(BTInputStringVar))]
        [XmlArrayItem(Type = typeof(BTInputStringBB))]
        public BTInputString[] EntityClass { get; set; }

        [XmlArray(ElementName = "Position")]
        [XmlArrayItem(Type = typeof(BTInputPosition))]
        [XmlArrayItem(Type = typeof(BTInputPositionVar))]
        [XmlArrayItem(Type = typeof(BTInputPositionBB))]
        public BTInputPosition[] Position { get; set; }

        [XmlArray(ElementName = "Rotation")]
        [XmlArrayItem(Type = typeof(BTInputVec3))]
        [XmlArrayItem(Type = typeof(BTInputVec3Var))]
        [XmlArrayItem(Type = typeof(BTInputVec3BB))]
        public BTInputVec3[] Rotation { get; set; }

        [XmlArray(ElementName = "Name")]
        [XmlArrayItem(Type = typeof(BTInputString))]
        [XmlArrayItem(Type = typeof(BTInputStringValue))]
        [XmlArrayItem(Type = typeof(BTInputStringVar))]
        [XmlArrayItem(Type = typeof(BTInputStringBB))]
        public BTInputString[] Name { get; set; }

        [XmlArray(ElementName = "Archetype")]
        [XmlArrayItem(Type = typeof(BTInputString))]
        [XmlArrayItem(Type = typeof(BTInputStringValue))]
        [XmlArrayItem(Type = typeof(BTInputStringVar))]
        [XmlArrayItem(Type = typeof(BTInputStringBB))]
        public BTInputString[] Archetype { get; set; }

    }
}
