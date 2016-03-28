using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "WeaponProceduralClipSway")]
    public partial class WeaponProceduralClipSway : WeaponProceduralClipBase
    {
        [XmlAttribute(AttributeName = "easeFactorInc")]
        public Single EaseFactorInc { get; set; }

        [XmlAttribute(AttributeName = "easeFactorDec")]
        public Single EaseFactorDec { get; set; }

        [XmlAttribute(AttributeName = "strafeScopeFactor")]
        public Single StrafeScopeFactor { get; set; }

        [XmlAttribute(AttributeName = "rotateScopeFactor")]
        public Single RotateScopeFactor { get; set; }

        [XmlAttribute(AttributeName = "velocityInterpolationMultiplier")]
        public Single VelocityInterpolationMultiplier { get; set; }

        [XmlAttribute(AttributeName = "velocityLowPassFilter")]
        public Single VelocityLowPassFilter { get; set; }

        [XmlAttribute(AttributeName = "accelerationSmoothing")]
        public Single AccelerationSmoothing { get; set; }

        [XmlAttribute(AttributeName = "accelerationFrontAugmentation")]
        public Single AccelerationFrontAugmentation { get; set; }

        [XmlAttribute(AttributeName = "verticalVelocityScale")]
        public Single VerticalVelocityScale { get; set; }

        [XmlAttribute(AttributeName = "sprintCameraAnimation")]
        public Single SprintCameraAnimation { get; set; }

        [XmlElement(ElementName = "lookOffset")]
        public Vec2 LookOffset { get; set; }

        [XmlElement(ElementName = "horizLookRot")]
        public Vec3 HorizLookRot { get; set; }

        [XmlElement(ElementName = "vertLookRot")]
        public Vec3 VertLookRot { get; set; }

        [XmlElement(ElementName = "strafeOffset")]
        public Vec3 StrafeOffset { get; set; }

        [XmlElement(ElementName = "sideStrafeRot")]
        public Vec3 SideStrafeRot { get; set; }

        [XmlElement(ElementName = "frontStrafeRot")]
        public Vec3 FrontStrafeRot { get; set; }

    }
}
