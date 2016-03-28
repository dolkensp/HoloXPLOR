using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CommunicationVariableConfig")]
    public partial class CommunicationVariableConfig
    {
        [XmlArray(ElementName = "variables")]
        [XmlArrayItem(Type = typeof(CommunicationVariableBool))]
        public CommunicationVariableBool[] Variables { get; set; }

    }
}
