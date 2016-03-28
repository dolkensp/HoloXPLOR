using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CommunicationVariableString")]
    public partial class CommunicationVariableString : CommunicationVariableBase
    {
        [XmlAttribute(AttributeName = "value")]
        public String Value { get; set; }

    }
}
