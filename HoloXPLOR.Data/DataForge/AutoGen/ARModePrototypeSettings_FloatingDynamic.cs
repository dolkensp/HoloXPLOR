using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ARModePrototypeSettings_FloatingDynamic")]
    public partial class ARModePrototypeSettings_FloatingDynamic : ARModeBasePrototypeSettings
    {
        [XmlAttribute(AttributeName = "HorizontalOffsetRange")]
        public Single HorizontalOffsetRange { get; set; }

        [XmlAttribute(AttributeName = "VerticalOffsetAbove")]
        public Single VerticalOffsetAbove { get; set; }

        [XmlAttribute(AttributeName = "VerticalOffsetBelow")]
        public Single VerticalOffsetBelow { get; set; }

    }
}
