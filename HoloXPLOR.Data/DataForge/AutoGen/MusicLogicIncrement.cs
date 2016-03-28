using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "MusicLogicIncrement")]
    public partial class MusicLogicIncrement : ParentMusicLogicNode
    {
        [XmlAttribute(AttributeName = "parameter")]
        public Guid Parameter { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public Single Value { get; set; }

    }
}
