using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "FoleyFootstepDefinition")]
    public partial class FoleyFootstepDefinition
    {
        [XmlAttribute(AttributeName = "velocityRTPCName")]
        public String VelocityRTPCName { get; set; }

        [XmlAttribute(AttributeName = "rotationRTPCName")]
        public String RotationRTPCName { get; set; }

        [XmlAttribute(AttributeName = "velocityRTPCMinimum")]
        public Single VelocityRTPCMinimum { get; set; }

        [XmlAttribute(AttributeName = "velocityRTPCMaximum")]
        public Single VelocityRTPCMaximum { get; set; }

        [XmlAttribute(AttributeName = "footMovementThreshold")]
        public Single FootMovementThreshold { get; set; }

        [XmlAttribute(AttributeName = "footRotationThreshold")]
        public Single FootRotationThreshold { get; set; }

        [XmlAttribute(AttributeName = "relativeSpeedThreshold")]
        public Single RelativeSpeedThreshold { get; set; }

        [XmlElement(ElementName = "surfaceMap")]
        public AudioFootstepSurfacesDefinition SurfaceMap { get; set; }

    }
}
