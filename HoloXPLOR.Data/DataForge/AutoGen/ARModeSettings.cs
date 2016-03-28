using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ARModeSettings")]
    public partial class ARModeSettings
    {
        [XmlAttribute(AttributeName = "PlayerLabelOffsetX")]
        public Single PlayerLabelOffsetX { get; set; }

        [XmlAttribute(AttributeName = "PlayerLabelOffsetY")]
        public Single PlayerLabelOffsetY { get; set; }

        [XmlAttribute(AttributeName = "PlayerLabelOffsetZ")]
        public Single PlayerLabelOffsetZ { get; set; }

        [XmlAttribute(AttributeName = "QueryFarPlaneDistanceMax")]
        public Single QueryFarPlaneDistanceMax { get; set; }

        [XmlAttribute(AttributeName = "QueryRaycastsActiveMax")]
        public Int32 QueryRaycastsActiveMax { get; set; }

        [XmlAttribute(AttributeName = "QueryTimeBetweenCenterFocusRaycasts")]
        public Single QueryTimeBetweenCenterFocusRaycasts { get; set; }

        [XmlAttribute(AttributeName = "QueryTimeBetweenComponentRaycasts")]
        public Single QueryTimeBetweenComponentRaycasts { get; set; }

        [XmlAttribute(AttributeName = "QueryTimeBetweenEntityRaycasts")]
        public Single QueryTimeBetweenEntityRaycasts { get; set; }

        [XmlAttribute(AttributeName = "FocusTransitionTime")]
        public Single FocusTransitionTime { get; set; }

        [XmlAttribute(AttributeName = "FocusZoneHard_WidthPercentage")]
        public Single FocusZoneHard_WidthPercentage { get; set; }

        [XmlAttribute(AttributeName = "FocusZoneHard_HeightPercentage")]
        public Single FocusZoneHard_HeightPercentage { get; set; }

        [XmlAttribute(AttributeName = "FocusZoneMedium_WidthPercentage")]
        public Single FocusZoneMedium_WidthPercentage { get; set; }

        [XmlAttribute(AttributeName = "FocusZoneMedium_HeightPercentage")]
        public Single FocusZoneMedium_HeightPercentage { get; set; }

        [XmlAttribute(AttributeName = "ReticleOffsetPercentageX")]
        public Single ReticleOffsetPercentageX { get; set; }

        [XmlAttribute(AttributeName = "ReticleOffsetPercentageY")]
        public Single ReticleOffsetPercentageY { get; set; }

        [XmlAttribute(AttributeName = "PrototypeMode")]
        public ARModePrototypeMode PrototypeMode { get; set; }

        [XmlElement(ElementName = "PROTO_FloatingDynamic")]
        public ARModePrototypeSettings_FloatingDynamic PROTO_FloatingDynamic { get; set; }

        [XmlElement(ElementName = "PROTO_FloatingStatic")]
        public ARModePrototypeSettings_FloatingStatic PROTO_FloatingStatic { get; set; }

    }
}
