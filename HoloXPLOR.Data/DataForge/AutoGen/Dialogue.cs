using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "Dialogue")]
    public partial class Dialogue
    {
        [XmlAttribute(AttributeName = "speaker")]
        public Guid Speaker { get; set; }

        [XmlAttribute(AttributeName = "localizedSubtitleText")]
        public String LocalizedSubtitleText { get; set; }

        [XmlAttribute(AttributeName = "tempText")]
        public String TempText { get; set; }

        [XmlAttribute(AttributeName = "sound")]
        public String Sound { get; set; }

        [XmlAttribute(AttributeName = "forceSubtitles")]
        public Boolean ForceSubtitles { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public Guid Id { get; set; }

    }
}
