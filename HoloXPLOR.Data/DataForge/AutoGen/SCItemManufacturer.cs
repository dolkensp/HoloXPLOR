using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SCItemManufacturer")]
    public partial class SCItemManufacturer
    {
        [XmlElement(ElementName = "Localization")]
        public SCItemLocalization Localization { get; set; }

        [XmlAttribute(AttributeName = "Logo")]
        public String Logo { get; set; }

    }
}
