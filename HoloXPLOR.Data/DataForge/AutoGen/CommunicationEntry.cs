using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CommunicationEntry")]
    public partial class CommunicationEntry
    {
        [XmlAttribute(AttributeName = "name")]
        public Guid Name { get; set; }

        [XmlAttribute(AttributeName = "method")]
        public eCommunicationChoiceMethod Method { get; set; }

        [XmlAttribute(AttributeName = "forceAnimation")]
        public Boolean ForceAnimation { get; set; }

        [XmlArray(ElementName = "variations")]
        [XmlArrayItem(Type = typeof(CommunicationVariation))]
        public CommunicationVariation[] Variations { get; set; }

    }
}
