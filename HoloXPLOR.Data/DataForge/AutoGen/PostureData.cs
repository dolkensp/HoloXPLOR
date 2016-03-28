using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "PostureData")]
    public partial class PostureData
    {
        [XmlAttribute(AttributeName = "Name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "Priority")]
        public Single Priority { get; set; }

        [XmlAttribute(AttributeName = "Lean")]
        public Single Lean { get; set; }

        [XmlAttribute(AttributeName = "PeekOver")]
        public Single PeekOver { get; set; }

        [XmlAttribute(AttributeName = "agInput")]
        public String AgInput { get; set; }

    }
}
