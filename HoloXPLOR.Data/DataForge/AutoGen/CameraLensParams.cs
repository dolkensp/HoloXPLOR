using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CameraLensParams")]
    public partial class CameraLensParams
    {
        [XmlAttribute(AttributeName = "BloomIntensity")]
        public Single BloomIntensity { get; set; }

        [XmlAttribute(AttributeName = "FlareIntensity")]
        public Single FlareIntensity { get; set; }

        [XmlArray(ElementName = "Streak")]
        [XmlArrayItem(Type = typeof(CameraLensStreak))]
        public CameraLensStreak[] Streak { get; set; }

        [XmlArray(ElementName = "GhostSets")]
        [XmlArrayItem(Type = typeof(CameraLensGhostSet))]
        public CameraLensGhostSet[] GhostSets { get; set; }

    }
}
