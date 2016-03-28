using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CommunicationSubtitleSettings")]
    public partial class CommunicationSubtitleSettings
    {
        [XmlAttribute(AttributeName = "allow")]
        public Boolean Allow { get; set; }

        [XmlAttribute(AttributeName = "variableName")]
        public String VariableName { get; set; }

    }
}
