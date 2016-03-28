using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ARModeBasePrototypeSettings")]
    public partial class ARModeBasePrototypeSettings
    {
        [XmlAttribute(AttributeName = "MinScale")]
        public Single MinScale { get; set; }

        [XmlAttribute(AttributeName = "MaxScale")]
        public Single MaxScale { get; set; }

        [XmlAttribute(AttributeName = "MinScaleDistance")]
        public Single MinScaleDistance { get; set; }

        [XmlAttribute(AttributeName = "MaxScaleDistance")]
        public Single MaxScaleDistance { get; set; }

        [XmlAttribute(AttributeName = "InterpolationSpeed")]
        public Single InterpolationSpeed { get; set; }

    }
}
