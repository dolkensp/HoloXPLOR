using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTPriorityChild")]
    public partial class BTPriorityChild : BTElement
    {
        [XmlAttribute(AttributeName = "child")]
        public String Child { get; set; }

    }
}
