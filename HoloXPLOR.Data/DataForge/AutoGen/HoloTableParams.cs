using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "HoloTableParams")]
    public partial class HoloTableParams
    {
        [XmlAttribute(AttributeName = "HoloTableGeometry")]
        public String HoloTableGeometry { get; set; }

        [XmlAttribute(AttributeName = "Helper")]
        public String Helper { get; set; }

    }
}
