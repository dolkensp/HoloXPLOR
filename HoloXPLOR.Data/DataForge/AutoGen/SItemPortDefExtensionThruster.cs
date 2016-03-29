using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SItemPortDefExtensionThruster")]
    public partial class SItemPortDefExtensionThruster : SItemPortDefExtensionTurret
    {
        [XmlAttribute(AttributeName = "ThrusterFlags")]
        public String ThrusterFlags { get; set; }

        [XmlElement(ElementName = "ForceSpin")]
        public Vec3 ForceSpin { get; set; }

        [XmlAttribute(AttributeName = "RangeAxes")]
        public String RangeAxes { get; set; }

        [XmlElement(ElementName = "HomeVector")]
        public Vec3 HomeVector { get; set; }

        [XmlArray(ElementName = "OptimalTMs")]
        [XmlArrayItem(Type = typeof(SOptimalTM))]
        public SOptimalTM[] OptimalTMs { get; set; }

    }
}
