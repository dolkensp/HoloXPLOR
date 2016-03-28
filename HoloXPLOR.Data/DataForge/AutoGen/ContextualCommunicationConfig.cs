using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ContextualCommunicationConfig")]
    public partial class ContextualCommunicationConfig
    {
        [XmlArray(ElementName = "responseEntries")]
        [XmlArrayItem(Type = typeof(ContextualCommunicationResponse))]
        public ContextualCommunicationResponse[] ResponseEntries { get; set; }

    }
}
