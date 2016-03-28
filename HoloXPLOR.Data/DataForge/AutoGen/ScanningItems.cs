using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ScanningItems")]
    public partial class ScanningItems
    {

        public ScanningItem Items { get; set; }


        public ScanningInformationData InfoTypes { get; set; }

    }
}
