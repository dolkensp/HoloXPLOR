using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "MissionObjective")]
    public partial class MissionObjective
    {
        [XmlAttribute(AttributeName = "Name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "ShortDesciption")]
        public String ShortDesciption { get; set; }

        [XmlAttribute(AttributeName = "LongDescription")]
        public String LongDescription { get; set; }

    }
}
