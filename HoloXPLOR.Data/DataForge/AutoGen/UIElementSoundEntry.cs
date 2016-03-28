using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "UIElementSoundEntry")]
    public partial class UIElementSoundEntry
    {
        [XmlAttribute(AttributeName = "SoundID")]
        public String SoundID { get; set; }

        [XmlAttribute(AttributeName = "SoundPath")]
        public String SoundPath { get; set; }

    }
}
