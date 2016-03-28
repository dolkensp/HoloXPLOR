using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "MovieClipTransformationInterpolator")]
    public partial class MovieClipTransformationInterpolator
    {
        [XmlAttribute(AttributeName = "interpolationTime")]
        public Single InterpolationTime { get; set; }

        [XmlArray(ElementName = "movieClipTransformationInterpolatorParams")]
        [XmlArrayItem(Type = typeof(MovieClipTransformationInterpolatorParams))]
        public MovieClipTransformationInterpolatorParams[] MovieClipTransformationInterpolatorParams { get; set; }

    }
}
