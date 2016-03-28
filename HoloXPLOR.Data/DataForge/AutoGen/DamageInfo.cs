using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "DamageInfo")]
    public partial class DamageInfo
    {
        [XmlAttribute(AttributeName = "DamagePhysical")]
        public Single DamagePhysical { get; set; }

        [XmlAttribute(AttributeName = "DamageEnergy")]
        public Single DamageEnergy { get; set; }

        [XmlAttribute(AttributeName = "DamageDistortion")]
        public Single DamageDistortion { get; set; }

    }
}
