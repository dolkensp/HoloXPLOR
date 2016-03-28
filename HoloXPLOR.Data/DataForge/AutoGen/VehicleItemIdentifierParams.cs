using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "VehicleItemIdentifierParams")]
    public partial class VehicleItemIdentifierParams
    {
        [XmlArray(ElementName = "PassiveScanningItems")]
        [XmlArrayItem(Type = typeof(BTInputTagBB))]
        public ScanningItemType[] PassiveScanningItems { get; set; }

        [XmlArray(ElementName = "LevelsTimeToScan")]
        [XmlArrayItem(Type = typeof(ProjectileParams))]
        [XmlArrayItem(Type = typeof(RocketProjectileParams))]
        [XmlArrayItem(Type = typeof(CounterMeasureProjectileParams))]
        [XmlArrayItem(Type = typeof(ShatterRocketProjectileParams))]
        [XmlArrayItem(Type = typeof(GrenadeProjectileParams))]
        [XmlArrayItem(Type = typeof(SmokeGrenadeProjectileParams))]
        [XmlArrayItem(Type = typeof(C4ProjectileParams))]
        [XmlArrayItem(Type = typeof(BulletProjectileParams))]
        public Single[] LevelsTimeToScan { get; set; }

        [XmlArray(ElementName = "ChannelScanRatios")]
        [XmlArrayItem(Type = typeof(ProjectileParams))]
        [XmlArrayItem(Type = typeof(RocketProjectileParams))]
        [XmlArrayItem(Type = typeof(CounterMeasureProjectileParams))]
        [XmlArrayItem(Type = typeof(ShatterRocketProjectileParams))]
        [XmlArrayItem(Type = typeof(GrenadeProjectileParams))]
        [XmlArrayItem(Type = typeof(SmokeGrenadeProjectileParams))]
        [XmlArrayItem(Type = typeof(C4ProjectileParams))]
        [XmlArrayItem(Type = typeof(BulletProjectileParams))]
        public Single[] ChannelScanRatios { get; set; }

        [XmlArray(ElementName = "ChannelMaxScanLevels")]
        [XmlArrayItem(Type = typeof(ProjectileParams))]
        [XmlArrayItem(Type = typeof(RocketProjectileParams))]
        [XmlArrayItem(Type = typeof(CounterMeasureProjectileParams))]
        [XmlArrayItem(Type = typeof(ShatterRocketProjectileParams))]
        [XmlArrayItem(Type = typeof(GrenadeProjectileParams))]
        [XmlArrayItem(Type = typeof(SmokeGrenadeProjectileParams))]
        [XmlArrayItem(Type = typeof(C4ProjectileParams))]
        [XmlArrayItem(Type = typeof(BulletProjectileParams))]
        public Int32[] ChannelMaxScanLevels { get; set; }

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
