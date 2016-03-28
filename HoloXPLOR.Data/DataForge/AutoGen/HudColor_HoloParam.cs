using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "HudColor_HoloParam")]
    public partial class HudColor_HoloParam
    {
        [XmlAttribute(AttributeName = "Name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "Opacity")]
        public Single Opacity { get; set; }

        [XmlAttribute(AttributeName = "Glow")]
        public Single Glow { get; set; }

        [XmlAttribute(AttributeName = "DiffuseOpacity")]
        public Single DiffuseOpacity { get; set; }

        [XmlAttribute(AttributeName = "RimOpacity")]
        public Single RimOpacity { get; set; }

        [XmlAttribute(AttributeName = "SilhouetteOpacity")]
        public Single SilhouetteOpacity { get; set; }

    }
}
