using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SPipeStateLevels")]
    public partial class SPipeStateLevels
    {
        [XmlAttribute(AttributeName = "Warning")]
        public Single Warning { get; set; }

        [XmlAttribute(AttributeName = "Critical")]
        public Single Critical { get; set; }

        [XmlAttribute(AttributeName = "Fail")]
        public Single Fail { get; set; }

    }
}
