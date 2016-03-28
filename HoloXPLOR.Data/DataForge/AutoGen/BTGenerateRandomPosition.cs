using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTGenerateRandomPosition")]
    public partial class BTGenerateRandomPosition : BTNode
    {
        [XmlArray(ElementName = "MinX")]
        [XmlArrayItem(Type = typeof(BTInputFloat))]
        [XmlArrayItem(Type = typeof(BTInputFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputFloatVar))]
        [XmlArrayItem(Type = typeof(BTInputFloatBB))]
        public BTInputFloat[] MinX { get; set; }

        [XmlArray(ElementName = "MaxX")]
        [XmlArrayItem(Type = typeof(BTInputFloat))]
        [XmlArrayItem(Type = typeof(BTInputFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputFloatVar))]
        [XmlArrayItem(Type = typeof(BTInputFloatBB))]
        public BTInputFloat[] MaxX { get; set; }

        [XmlArray(ElementName = "MinY")]
        [XmlArrayItem(Type = typeof(BTInputFloat))]
        [XmlArrayItem(Type = typeof(BTInputFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputFloatVar))]
        [XmlArrayItem(Type = typeof(BTInputFloatBB))]
        public BTInputFloat[] MinY { get; set; }

        [XmlArray(ElementName = "MaxY")]
        [XmlArrayItem(Type = typeof(BTInputFloat))]
        [XmlArrayItem(Type = typeof(BTInputFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputFloatVar))]
        [XmlArrayItem(Type = typeof(BTInputFloatBB))]
        public BTInputFloat[] MaxY { get; set; }

        [XmlArray(ElementName = "MinZ")]
        [XmlArrayItem(Type = typeof(BTInputFloat))]
        [XmlArrayItem(Type = typeof(BTInputFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputFloatVar))]
        [XmlArrayItem(Type = typeof(BTInputFloatBB))]
        public BTInputFloat[] MinZ { get; set; }

        [XmlArray(ElementName = "MaxZ")]
        [XmlArrayItem(Type = typeof(BTInputFloat))]
        [XmlArrayItem(Type = typeof(BTInputFloatValue))]
        [XmlArrayItem(Type = typeof(BTInputFloatVar))]
        [XmlArrayItem(Type = typeof(BTInputFloatBB))]
        public BTInputFloat[] MaxZ { get; set; }

        [XmlArray(ElementName = "ReferencePos")]
        [XmlArrayItem(Type = typeof(BTInputPosition))]
        [XmlArrayItem(Type = typeof(BTInputPositionVar))]
        [XmlArrayItem(Type = typeof(BTInputPositionBB))]
        public BTInputPosition[] ReferencePos { get; set; }

        [XmlArray(ElementName = "Result")]
        [XmlArrayItem(Type = typeof(BTOutput))]
        public BTOutput[] Result { get; set; }

    }
}
