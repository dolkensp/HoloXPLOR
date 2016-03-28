using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "Flash_Palette")]
    public partial class Flash_Palette
    {
        [XmlArray(ElementName = "Entries")]
        [XmlArrayItem(Type = typeof(Flash_PaletteEntry))]
        public Flash_PaletteEntry[] Entries { get; set; }

    }
}
