using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ARModePrototypeSettings_FloatingStatic")]
    public partial class ARModePrototypeSettings_FloatingStatic : ARModeBasePrototypeSettings
    {
        [XmlAttribute(AttributeName = "LabelOffsetPercentageX")]
        public Single LabelOffsetPercentageX { get; set; }

        [XmlAttribute(AttributeName = "LabelOffsetPercentageY")]
        public Single LabelOffsetPercentageY { get; set; }

        [XmlAttribute(AttributeName = "LabelFloatRectangleWidth")]
        public Single LabelFloatRectangleWidth { get; set; }

        [XmlAttribute(AttributeName = "LabelFloatRectangleHeight")]
        public Single LabelFloatRectangleHeight { get; set; }

    }
}
