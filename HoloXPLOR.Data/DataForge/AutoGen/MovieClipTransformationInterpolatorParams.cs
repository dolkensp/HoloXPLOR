using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "MovieClipTransformationInterpolatorParams")]
    public partial class MovieClipTransformationInterpolatorParams
    {
        [XmlAttribute(AttributeName = "movieClipName")]
        public String MovieClipName { get; set; }

        [XmlElement(ElementName = "transformationInterpolatorParams")]
        public TransformationInterpolatorParams TransformationInterpolatorParams { get; set; }

    }
}
