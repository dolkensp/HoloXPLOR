using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SPipePoolProperties")]
    public partial class SPipePoolProperties
    {
        [XmlAttribute(AttributeName = "IsCritical")]
        public Boolean IsCritical { get; set; }

    }
}
