using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ShatterRocketProjectileParams")]
    public partial class ShatterRocketProjectileParams : RocketProjectileParams
    {
        [XmlAttribute(AttributeName = "fragmentCount")]
        public Int32 FragmentCount { get; set; }

        [XmlElement(ElementName = "fragmentVelocity")]
        public Vec3 FragmentVelocity { get; set; }

        [XmlAttribute(AttributeName = "fragmentAmmoType")]
        public String FragmentAmmoType { get; set; }

    }
}
