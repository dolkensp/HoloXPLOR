using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ScanningInformationData")]
    public partial class ScanningInformationData
    {
        [XmlAttribute(AttributeName = "Name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "DisplayType")]
        public ScanningItemInfoDisplay DisplayType { get; set; }

        [XmlAttribute(AttributeName = "DisplayPrecision")]
        public Int32 DisplayPrecision { get; set; }

    }
}
