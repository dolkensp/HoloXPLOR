using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "GreaterThan")]
    public partial class GreaterThan : MusicLogicCondition
    {
        [XmlAttribute(AttributeName = "parameter")]
        public Guid Parameter { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public Single Value { get; set; }

    }
}
