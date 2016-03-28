using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "WeaponProceduralClipRecoil")]
    public partial class WeaponProceduralClipRecoil : WeaponProceduralClipBase
    {
        [XmlAttribute(AttributeName = "dampStrength")]
        public Single DampStrength { get; set; }

        [XmlAttribute(AttributeName = "fireRecoilTime")]
        public Single FireRecoilTime { get; set; }

        [XmlAttribute(AttributeName = "fireRecoilStrengthFirst")]
        public Single FireRecoilStrengthFirst { get; set; }

        [XmlAttribute(AttributeName = "fireRecoilStrength")]
        public Single FireRecoilStrength { get; set; }

        [XmlAttribute(AttributeName = "angleRecoilStrength")]
        public Single AngleRecoilStrength { get; set; }

        [XmlAttribute(AttributeName = "randomness")]
        public Single Randomness { get; set; }

    }
}
