using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "AudioFootstepSurfaceMapping")]
    public partial class AudioFootstepSurfaceMapping
    {
        [XmlAttribute(AttributeName = "surfaceType")]
        public String SurfaceType { get; set; }

        [XmlAttribute(AttributeName = "heelLandAudioTrigger")]
        public String HeelLandAudioTrigger { get; set; }

        [XmlAttribute(AttributeName = "toeLandAudioTrigger")]
        public String ToeLandAudioTrigger { get; set; }

        [XmlAttribute(AttributeName = "footLiftAudioTrigger")]
        public String FootLiftAudioTrigger { get; set; }

        [XmlAttribute(AttributeName = "turnPlayAudioTrigger")]
        public String TurnPlayAudioTrigger { get; set; }

        [XmlAttribute(AttributeName = "turnStopAudioTrigger")]
        public String TurnStopAudioTrigger { get; set; }

    }
}
