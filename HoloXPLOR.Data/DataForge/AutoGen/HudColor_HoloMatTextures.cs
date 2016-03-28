using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "HudColor_HoloMatTextures")]
    public partial class HudColor_HoloMatTextures
    {
        [XmlAttribute(AttributeName = "DiffuseName")]
        public String DiffuseName { get; set; }

    }
}
