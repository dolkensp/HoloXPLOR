using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "HudColor_HoloMatColors")]
    public partial class HudColor_HoloMatColors
    {
        [XmlElement(ElementName = "Diffuse")]
        public RGB8 Diffuse { get; set; }

        [XmlElement(ElementName = "Emissive")]
        public RGB8 Emissive { get; set; }

        [XmlElement(ElementName = "RimColor")]
        public RGB8 RimColor { get; set; }

        [XmlElement(ElementName = "SilhouetteColor")]
        public RGB8 SilhouetteColor { get; set; }

        [XmlArray(ElementName = "Textures")]
        [XmlArrayItem(Type = typeof(HudColor_HoloMatTextures))]
        public HudColor_HoloMatTextures[] Textures { get; set; }

    }
}
