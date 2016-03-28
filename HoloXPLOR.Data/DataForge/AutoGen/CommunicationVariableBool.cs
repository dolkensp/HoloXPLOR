using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CommunicationVariableBool")]
    public partial class CommunicationVariableBool : CommunicationVariableBase
    {
        [XmlAttribute(AttributeName = "value")]
        public Boolean Value { get; set; }

    }
}
