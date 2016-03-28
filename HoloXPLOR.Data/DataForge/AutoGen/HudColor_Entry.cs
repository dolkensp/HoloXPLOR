using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "HudColor_Entry")]
    public partial class HudColor_Entry
    {
        [XmlArray(ElementName = "FlashColor")]
        [XmlArrayItem(Type = typeof(RGBA8))]
        public RGBA8[] FlashColor { get; set; }

        [XmlElement(ElementName = "HoloMatColors")]
        public HudColor_HoloMatColors HoloMatColors { get; set; }

    }
}
