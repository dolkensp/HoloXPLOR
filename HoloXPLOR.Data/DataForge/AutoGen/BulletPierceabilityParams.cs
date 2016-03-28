using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BulletPierceabilityParams")]
    public partial class BulletPierceabilityParams
    {
        [XmlAttribute(AttributeName = "damageFalloffLevel1")]
        public Single DamageFalloffLevel1 { get; set; }

        [XmlAttribute(AttributeName = "damageFalloffLevel2")]
        public Single DamageFalloffLevel2 { get; set; }

        [XmlAttribute(AttributeName = "damageFalloffLevel3")]
        public Single DamageFalloffLevel3 { get; set; }

        [XmlAttribute(AttributeName = "maxPenetrationThickness")]
        public Single MaxPenetrationThickness { get; set; }

    }
}
