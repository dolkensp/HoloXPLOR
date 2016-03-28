using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SInteractionPointParams")]
    public partial class SInteractionPointParams
    {
        [XmlAttribute(AttributeName = "HelperName")]
        public String HelperName { get; set; }

        [XmlElement(ElementName = "Offset")]
        public QuatT Offset { get; set; }

        [XmlArray(ElementName = "Interactions")]
        [XmlArrayItem(Type = typeof(SInteractionParams))]
        public SInteractionParams[] Interactions { get; set; }

    }
}
