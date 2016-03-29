using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "TransformationInterpolatorParams")]
    public partial class TransformationInterpolatorParams
    {
        [XmlElement(ElementName = "startOffsetValues")]
        public Vec3 StartOffsetValues { get; set; }

        [XmlElement(ElementName = "endOffsetValues")]
        public Vec3 EndOffsetValues { get; set; }

        [XmlArray(ElementName = "offsetInterpolationModes")]
        [XmlArrayItem(ElementName = "Enum", Type=typeof(_InterpolationMode))]
        public _InterpolationMode[] OffsetInterpolationModes { get; set; }

        [XmlElement(ElementName = "startRotationValues")]
        public Ang3 StartRotationValues { get; set; }

        [XmlElement(ElementName = "endRotationValues")]
        public Ang3 EndRotationValues { get; set; }

        [XmlArray(ElementName = "rotationInterpolationModes")]
        [XmlArrayItem(ElementName = "Enum", Type=typeof(_InterpolationMode))]
        public _InterpolationMode[] RotationInterpolationModes { get; set; }

        [XmlAttribute(AttributeName = "startScaleValue")]
        public Single StartScaleValue { get; set; }

        [XmlAttribute(AttributeName = "endScaleValue")]
        public Single EndScaleValue { get; set; }

        [XmlAttribute(AttributeName = "scaleInterpolationMode")]
        public InterpolationMode ScaleInterpolationMode { get; set; }

    }
}
