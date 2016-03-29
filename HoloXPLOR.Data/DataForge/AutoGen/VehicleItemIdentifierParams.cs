using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "VehicleItemIdentifierParams")]
    public partial class VehicleItemIdentifierParams
    {
        [XmlArray(ElementName = "PassiveScanningItems")]
        [XmlArrayItem(ElementName = "Enum", Type=typeof(_ScanningItemType))]
        public _ScanningItemType[] PassiveScanningItems { get; set; }

        [XmlArray(ElementName = "LevelsTimeToScan")]
        [XmlArrayItem(ElementName = "Single", Type=typeof(_Single))]
        public _Single[] LevelsTimeToScan { get; set; }

        [XmlArray(ElementName = "ChannelScanRatios")]
        [XmlArrayItem(ElementName = "Single", Type=typeof(_Single))]
        public _Single[] ChannelScanRatios { get; set; }

        [XmlArray(ElementName = "ChannelMaxScanLevels")]
        [XmlArrayItem(ElementName = "Int32", Type=typeof(_Int32))]
        public _Int32[] ChannelMaxScanLevels { get; set; }

        [XmlAttribute(AttributeName = "OptimalScanDistance")]
        public Single OptimalScanDistance { get; set; }

        [XmlAttribute(AttributeName = "MaximumRange")]
        public Single MaximumRange { get; set; }

        [XmlAttribute(AttributeName = "TimeToScanScaleAtMaxRange")]
        public Single TimeToScanScaleAtMaxRange { get; set; }

        [XmlAttribute(AttributeName = "TimeToScanCurveParameter")]
        public Single TimeToScanCurveParameter { get; set; }

        [XmlAttribute(AttributeName = "MaxConcurrentScans")]
        public Int32 MaxConcurrentScans { get; set; }

        [XmlAttribute(AttributeName = "MaxPowerRatio")]
        public Single MaxPowerRatio { get; set; }

        [XmlAttribute(AttributeName = "TimeToScanScaleAtMaxPower")]
        public Single TimeToScanScaleAtMaxPower { get; set; }

    }
}
