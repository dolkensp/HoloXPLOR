using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "InnerThought_Config")]
    public partial class InnerThought_Config
    {
        [XmlAttribute(AttributeName = "GeometryFile")]
        public String GeometryFile { get; set; }

        [XmlAttribute(AttributeName = "MetricsFile")]
        public String MetricsFile { get; set; }

        [XmlArray(ElementName = "LetterNodes")]
        [XmlArrayItem(Type = typeof(InnerThought_LetterNodes))]
        public InnerThought_LetterNodes[] LetterNodes { get; set; }

    }
}
