using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "MusicEventResponse")]
    public partial class MusicEventResponse : ParentMusicLogicNode
    {
        [XmlAttribute(AttributeName = "musicEvent")]
        public Guid MusicEvent { get; set; }

    }
}
