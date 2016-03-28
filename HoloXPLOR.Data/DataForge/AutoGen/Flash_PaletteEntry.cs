using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "Flash_PaletteEntry")]
    public partial class Flash_PaletteEntry
    {
        [XmlAttribute(AttributeName = "Name")]
        public String Name { get; set; }

        [XmlArray(ElementName = "FlashColor")]
        [XmlArrayItem(Type = typeof(RGBA8))]
        public RGBA8[] FlashColor { get; set; }

    }
}
