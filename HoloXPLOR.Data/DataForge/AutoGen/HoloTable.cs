using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "HoloTable")]
    public partial class HoloTable : StaticEnvironmentItem
    {
        [XmlElement(ElementName = "HoloTableItemParams")]
        public HoloTableParams HoloTableItemParams { get; set; }

    }
}
