using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "AwardService_Award")]
    public partial class AwardService_Award
    {
        [XmlAttribute(AttributeName = "Name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "Title")]
        public String Title { get; set; }

        [XmlAttribute(AttributeName = "Message")]
        public String Message { get; set; }

    }
}
