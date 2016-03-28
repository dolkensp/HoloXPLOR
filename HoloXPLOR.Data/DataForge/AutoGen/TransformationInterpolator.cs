using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "TransformationInterpolator")]
    public partial class TransformationInterpolator
    {
        [XmlAttribute(AttributeName = "interpolationTime")]
        public Single InterpolationTime { get; set; }

        [XmlElement(ElementName = "transformationInterpolatorParams")]
        public TransformationInterpolatorParams TransformationInterpolatorParams { get; set; }

    }
}
