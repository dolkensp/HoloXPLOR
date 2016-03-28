using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SItemPortDefExtensionTurret")]
    public partial class SItemPortDefExtensionTurret : SItemPortDefExtensionBase
    {
        [XmlElement(ElementName = "YawLimit")]
        public Ang3 YawLimit { get; set; }

        [XmlElement(ElementName = "PitchLimit")]
        public Ang3 PitchLimit { get; set; }

        [XmlElement(ElementName = "RollLimit")]
        public Ang3 RollLimit { get; set; }

    }
}
