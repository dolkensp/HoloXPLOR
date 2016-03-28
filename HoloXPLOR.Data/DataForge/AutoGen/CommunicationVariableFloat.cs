using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CommunicationVariableFloat")]
    public partial class CommunicationVariableFloat : CommunicationVariableBase
    {
        [XmlAttribute(AttributeName = "value")]
        public Single Value { get; set; }

    }
}
