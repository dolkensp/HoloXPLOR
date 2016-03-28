using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SItemPortConnectionParam")]
    public partial class SItemPortConnectionParam
    {
        [XmlAttribute(AttributeName = "Name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "Klass")]
        public EPipeClass Klass { get; set; }

        [XmlElement(ElementName = "Priority")]
        public SItemPortConnectionPriorityParam Priority { get; set; }

    }
}
