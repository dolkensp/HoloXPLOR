using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "StandAloneEpisode")]
    public partial class StandAloneEpisode
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlArray(ElementName = "chapters")]
        [XmlArrayItem(Type = typeof(StandAloneChapter))]
        [XmlArrayItem(Type = typeof(StandAloneChapterStart))]
        public StandAloneChapter[] Chapters { get; set; }

    }
}
