using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SItemPortDefExtensionThruster")]
    public partial class SItemPortDefExtensionThruster : SItemPortDefExtensionTurret
    {
        [XmlAttribute(AttributeName = "ThrusterFlags")]
        public String ThrusterFlags { get; set; }

        [XmlArray(ElementName = "OptimalTMs")]
        [XmlArrayItem(Type = typeof(SOptimalTM))]
        public SOptimalTM[] OptimalTMs { get; set; }

    }
}
