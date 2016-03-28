using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "HudColors")]
    public partial class HudColors
    {
        [XmlArray(ElementName = "HoloMatParams")]
        [XmlArrayItem(Type = typeof(HudColor_HoloParam))]
        public HudColor_HoloParam[] HoloMatParams { get; set; }

        [XmlArray(ElementName = "Palettes")]
        [XmlArrayItem(Type = typeof(HudColor_Palette))]
        public HudColor_Palette[] Palettes { get; set; }

    }
}
