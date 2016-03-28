using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "MusicLogicTrigger")]
    public partial class MusicLogicTrigger : MusicLogicNode
    {
        [XmlAttribute(AttributeName = "trigger")]
        public String Trigger { get; set; }

    }
}
