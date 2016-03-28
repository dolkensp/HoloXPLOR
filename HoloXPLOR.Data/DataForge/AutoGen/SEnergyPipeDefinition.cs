using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SEnergyPipeDefinition")]
    public partial class SEnergyPipeDefinition
    {
        [XmlAttribute(AttributeName = "Name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "Klass")]
        public EPipeClass Klass { get; set; }

        [XmlAttribute(AttributeName = "Priority")]
        public UInt32 Priority { get; set; }

        [XmlAttribute(AttributeName = "Type")]
        public EItemPipeType Type { get; set; }

    }
}
