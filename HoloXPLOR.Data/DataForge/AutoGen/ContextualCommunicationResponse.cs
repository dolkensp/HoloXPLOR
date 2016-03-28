using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ContextualCommunicationResponse")]
    public partial class ContextualCommunicationResponse
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "concept")]
        public eContextualCommunicationConcept Concept { get; set; }

        [XmlAttribute(AttributeName = "customConcept")]
        public String CustomConcept { get; set; }

        [XmlAttribute(AttributeName = "refireDelay")]
        public Single RefireDelay { get; set; }

        [XmlArray(ElementName = "rules")]
        [XmlArrayItem(Type = typeof(ContextualCommunicationCondition))]
        public ContextualCommunicationCondition[] Rules { get; set; }

        [XmlElement(ElementName = "response")]
        public CommunicationRequest Response { get; set; }

        [XmlArray(ElementName = "memoryVariables")]
        [XmlArrayItem(Type = typeof(CommunicationVariableBase))]
        [XmlArrayItem(Type = typeof(CommunicationVariableBool))]
        [XmlArrayItem(Type = typeof(CommunicationVariableFloat))]
        [XmlArrayItem(Type = typeof(CommunicationVariableString))]
        public CommunicationVariableBase[] MemoryVariables { get; set; }

    }
}
