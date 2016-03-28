using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTTimestampOnSignal")]
    public partial class BTTimestampOnSignal
    {
        [XmlAttribute(AttributeName = "onSignal")]
        public String OnSignal { get; set; }

        [XmlAttribute(AttributeName = "timestampVariable")]
        public String TimestampVariable { get; set; }

    }
}
