using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SPipeStateValueProperties")]
    public partial class SPipeStateValueProperties
    {
        [XmlAttribute(AttributeName = "IsCritical")]
        public Boolean IsCritical { get; set; }

        [XmlAttribute(AttributeName = "IgnorePool")]
        public Boolean IgnorePool { get; set; }

    }
}
