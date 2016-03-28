using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "HudColor_CustomEntry")]
    public partial class HudColor_CustomEntry : HudColor_Entry
    {
        [XmlAttribute(AttributeName = "Name")]
        public String Name { get; set; }

    }
}
