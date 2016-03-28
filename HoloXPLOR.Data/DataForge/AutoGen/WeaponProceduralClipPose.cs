using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "WeaponProceduralClipPose")]
    public partial class WeaponProceduralClipPose : WeaponProceduralClipBase
    {
        [XmlAttribute(AttributeName = "poseType")]
        public WeaponPoseType PoseType { get; set; }

        [XmlAttribute(AttributeName = "zoomTransitionAngle")]
        public Single ZoomTransitionAngle { get; set; }

        [XmlElement(ElementName = "position")]
        public Vec3 Position { get; set; }

        [XmlElement(ElementName = "rotation")]
        public Vec3 Rotation { get; set; }

    }
}
