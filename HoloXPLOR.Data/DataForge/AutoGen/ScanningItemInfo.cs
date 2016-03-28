using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ScanningItemInfo")]
    public partial class ScanningItemInfo
    {
        [XmlAttribute(AttributeName = "InformationType")]
        public ScanningItemInformation InformationType { get; set; }

        [XmlAttribute(AttributeName = "RealTimeUpdate")]
        public Boolean RealTimeUpdate { get; set; }

    }
}
