using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SPipeProperties")]
    public partial class SPipeProperties
    {
        [XmlAttribute(AttributeName = "AllowThrottle")]
        public Boolean AllowThrottle { get; set; }

        [XmlAttribute(AttributeName = "AllowConstraint")]
        public Boolean AllowConstraint { get; set; }

    }
}
