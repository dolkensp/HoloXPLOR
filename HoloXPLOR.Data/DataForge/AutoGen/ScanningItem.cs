using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ScanningItem")]
    public partial class ScanningItem
    {
        [XmlAttribute(AttributeName = "ScanLevel")]
        public Int32 ScanLevel { get; set; }

        [XmlAttribute(AttributeName = "Channel")]
        public ScanningChannel Channel { get; set; }

        [XmlAttribute(AttributeName = "ParentItem")]
        public ScanningItemType ParentItem { get; set; }

        [XmlAttribute(AttributeName = "ParentItem2")]
        public ScanningItemType ParentItem2 { get; set; }

        [XmlArray(ElementName = "Information")]
        [XmlArrayItem(Type = typeof(ScanningItemInfo))]
        public ScanningItemInfo[] Information { get; set; }

    }
}
