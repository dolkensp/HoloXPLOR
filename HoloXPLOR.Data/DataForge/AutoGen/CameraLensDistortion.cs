using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CameraLensDistortion")]
    public partial class CameraLensDistortion
    {
        [XmlAttribute(AttributeName = "Radial")]
        public Single Radial { get; set; }

        [XmlAttribute(AttributeName = "Spherical")]
        public Single Spherical { get; set; }

        [XmlAttribute(AttributeName = "Coma")]
        public Single Coma { get; set; }

        [XmlAttribute(AttributeName = "Curvature")]
        public Single Curvature { get; set; }

    }
}
