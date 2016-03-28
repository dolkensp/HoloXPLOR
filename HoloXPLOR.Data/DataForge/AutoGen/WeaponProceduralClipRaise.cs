using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "WeaponProceduralClipRaise")]
    public partial class WeaponProceduralClipRaise : WeaponProceduralClipBase
    {
        [XmlElement(ElementName = "weaponRaise")]
        public Ang3 WeaponRaise { get; set; }

        [XmlElement(ElementName = "weaponShift")]
        public Vec3 WeaponShift { get; set; }

    }
}
