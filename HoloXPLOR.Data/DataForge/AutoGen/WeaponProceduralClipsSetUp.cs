using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "WeaponProceduralClipsSetUp")]
    public partial class WeaponProceduralClipsSetUp
    {
        [XmlAttribute(AttributeName = "motionState")]
        public WeaponMotionState MotionState { get; set; }

        [XmlAttribute(AttributeName = "aimStance")]
        public WeaponAimStance AimStance { get; set; }

        [XmlAttribute(AttributeName = "motionStance")]
        public WeaponMotionStance MotionStance { get; set; }

        [XmlAttribute(AttributeName = "coverStance")]
        public WeaponCoverStance CoverStance { get; set; }

        [XmlArray(ElementName = "weaponProceduralClips")]
        [XmlArrayItem(Type = typeof(WeaponProceduralClip))]
        public Guid[] WeaponProceduralClips { get; set; }

    }
}
