using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "HUDSilhouetteData")]
    public partial class HUDSilhouetteData
    {
        [XmlAttribute(AttributeName = "mode")]
        public HUDSilhouetteMode Mode { get; set; }

        [XmlArray(ElementName = "color")]
        [XmlArrayItem(Type = typeof(RGBA))]
        public RGBA[] Color { get; set; }

        [XmlAttribute(AttributeName = "transitionTime")]
        public Single TransitionTime { get; set; }

    }
}
