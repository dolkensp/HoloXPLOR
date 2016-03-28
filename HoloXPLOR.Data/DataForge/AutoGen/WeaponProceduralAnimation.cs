using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "WeaponProceduralAnimation")]
    public partial class WeaponProceduralAnimation
    {
        [XmlArray(ElementName = "weaponProceduralClipsSetUp")]
        [XmlArrayItem(Type = typeof(WeaponProceduralClipsSetUp))]
        public WeaponProceduralClipsSetUp[] WeaponProceduralClipsSetUp { get; set; }

    }
}
