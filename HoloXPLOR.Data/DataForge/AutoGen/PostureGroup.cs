using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "PostureGroup")]
    public partial class PostureGroup
    {
        [XmlAttribute(AttributeName = "Type")]
        public PostureType Type { get; set; }

        [XmlAttribute(AttributeName = "Stance")]
        public AgentStance Stance { get; set; }

        [XmlArray(ElementName = "Postures")]
        [XmlArrayItem(Type = typeof(PostureData))]
        public PostureData[] Postures { get; set; }

    }
}
