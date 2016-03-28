using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SItemPortConnectionPriorityParam")]
    public partial class SItemPortConnectionPriorityParam
    {
        [XmlAttribute(AttributeName = "Critical")]
        public UInt32 Critical { get; set; }

        [XmlAttribute(AttributeName = "Manageable")]
        public UInt32 Manageable { get; set; }

        [XmlAttribute(AttributeName = "Aux")]
        public UInt32 Aux { get; set; }

    }
}
