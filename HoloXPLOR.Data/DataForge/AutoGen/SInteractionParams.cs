using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SInteractionParams")]
    public partial class SInteractionParams
    {
        [XmlAttribute(AttributeName = "Enabled")]
        public Boolean Enabled { get; set; }

        [XmlAttribute(AttributeName = "InteractionName")]
        public String InteractionName { get; set; }

        [XmlAttribute(AttributeName = "DisplayName")]
        public String DisplayName { get; set; }

    }
}
