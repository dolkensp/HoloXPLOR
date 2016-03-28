using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "TPSOption")]
    public partial class TPSOption
    {
        [XmlArray(ElementName = "Parameters")]
        [XmlArrayItem(Type = typeof(TPSInput))]
        [XmlArrayItem(Type = typeof(TPSInputBoolValue))]
        [XmlArrayItem(Type = typeof(TPSInputIntValue))]
        [XmlArrayItem(Type = typeof(TPSInputFloatValue))]
        [XmlArrayItem(Type = typeof(TPSInputStringValue))]
        public TPSInput[] Parameters { get; set; }

        [XmlArray(ElementName = "Generation")]
        [XmlArrayItem(Type = typeof(TPSInput))]
        [XmlArrayItem(Type = typeof(TPSInputBoolValue))]
        [XmlArrayItem(Type = typeof(TPSInputIntValue))]
        [XmlArrayItem(Type = typeof(TPSInputFloatValue))]
        [XmlArrayItem(Type = typeof(TPSInputStringValue))]
        public TPSInput[] Generation { get; set; }

        [XmlArray(ElementName = "Conditions")]
        [XmlArrayItem(Type = typeof(TPSInput))]
        [XmlArrayItem(Type = typeof(TPSInputBoolValue))]
        [XmlArrayItem(Type = typeof(TPSInputIntValue))]
        [XmlArrayItem(Type = typeof(TPSInputFloatValue))]
        [XmlArrayItem(Type = typeof(TPSInputStringValue))]
        public TPSInput[] Conditions { get; set; }

        [XmlArray(ElementName = "Weights")]
        [XmlArrayItem(Type = typeof(TPSInput))]
        [XmlArrayItem(Type = typeof(TPSInputBoolValue))]
        [XmlArrayItem(Type = typeof(TPSInputIntValue))]
        [XmlArrayItem(Type = typeof(TPSInputFloatValue))]
        [XmlArrayItem(Type = typeof(TPSInputStringValue))]
        public TPSInput[] Weights { get; set; }

    }
}
