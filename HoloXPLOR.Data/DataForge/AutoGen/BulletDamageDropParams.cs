using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BulletDamageDropParams")]
    public partial class BulletDamageDropParams
    {
        [XmlElement(ElementName = "damageDropMinDistance")]
        public DamageInfo DamageDropMinDistance { get; set; }

        [XmlElement(ElementName = "damageDropPerMeter")]
        public DamageInfo DamageDropPerMeter { get; set; }

        [XmlElement(ElementName = "damageDropMinDamage")]
        public DamageInfo DamageDropMinDamage { get; set; }

        [XmlAttribute(AttributeName = "pointBlankAmount")]
        public Single PointBlankAmount { get; set; }

        [XmlAttribute(AttributeName = "pointBlankDistance")]
        public Single PointBlankDistance { get; set; }

        [XmlAttribute(AttributeName = "pointBlankFalloffDistance")]
        public Single PointBlankFalloffDistance { get; set; }

    }
}
