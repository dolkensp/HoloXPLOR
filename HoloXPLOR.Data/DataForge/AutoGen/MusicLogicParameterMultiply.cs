using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "MusicLogicParameterMultiply")]
    public partial class MusicLogicParameterMultiply : MusicLogicNode
    {
        [XmlAttribute(AttributeName = "parameter")]
        public Guid Parameter { get; set; }

    }
}
