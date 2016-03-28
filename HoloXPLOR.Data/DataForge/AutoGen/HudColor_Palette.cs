using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "HudColor_Palette")]
    public partial class HudColor_Palette
    {
        [XmlAttribute(AttributeName = "Name")]
        public String Name { get; set; }


        public HudColor_Entry StandardEntries { get; set; }

        [XmlArray(ElementName = "CustomEntries")]
        [XmlArrayItem(Type = typeof(HudColor_CustomEntry))]
        public HudColor_CustomEntry[] CustomEntries { get; set; }

    }
}
