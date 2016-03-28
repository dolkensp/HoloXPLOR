using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "AudioFootstepSurfacesDefinition")]
    public partial class AudioFootstepSurfacesDefinition
    {
        [XmlArray(ElementName = "audioSurfaces")]
        [XmlArrayItem(Type = typeof(AudioFootstepSurfaceMapping))]
        public AudioFootstepSurfaceMapping[] AudioSurfaces { get; set; }

    }
}
