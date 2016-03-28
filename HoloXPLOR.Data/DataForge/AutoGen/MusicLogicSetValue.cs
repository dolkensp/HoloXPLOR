using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "MusicLogicSetValue")]
    public partial class MusicLogicSetValue : MusicLogicNode
    {
        [XmlAttribute(AttributeName = "parameter")]
        public Guid Parameter { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public Single Value { get; set; }

    }
}
