using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "WeaponProceduralClip")]
    public partial class WeaponProceduralClip
    {
        [XmlArray(ElementName = "weaponProceduralClipBase")]
        [XmlArrayItem(Type = typeof(WeaponProceduralClipBase))]
        [XmlArrayItem(Type = typeof(WeaponProceduralClipSway))]
        [XmlArrayItem(Type = typeof(WeaponProceduralClipHandsOverlay))]
        [XmlArrayItem(Type = typeof(WeaponProceduralClipRecoil))]
        [XmlArrayItem(Type = typeof(WeaponProceduralClipPose))]
        [XmlArrayItem(Type = typeof(WeaponProceduralClipRaise))]
        public WeaponProceduralClipBase[] WeaponProceduralClipBase { get; set; }

    }
}
