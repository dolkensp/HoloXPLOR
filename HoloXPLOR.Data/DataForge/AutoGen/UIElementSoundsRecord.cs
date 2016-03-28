using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "UIElementSoundsRecord")]
    public partial class UIElementSoundsRecord
    {
        [XmlArray(ElementName = "SoundDBs")]
        [XmlArrayItem(Type = typeof(UIElementSoundEntry))]
        public UIElementSoundEntry[] SoundDBs { get; set; }

    }
}
