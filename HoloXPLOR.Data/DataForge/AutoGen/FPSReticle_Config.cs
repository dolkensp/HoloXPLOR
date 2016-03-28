using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "FPSReticle_Config")]
    public partial class FPSReticle_Config
    {
        [XmlAttribute(AttributeName = "AimAveragePoints")]
        public Byte AimAveragePoints { get; set; }

        [XmlAttribute(AttributeName = "FlashWidth")]
        public UInt16 FlashWidth { get; set; }

        [XmlAttribute(AttributeName = "FlashHeight")]
        public UInt16 FlashHeight { get; set; }

        [XmlAttribute(AttributeName = "SpreadSize")]
        public Single SpreadSize { get; set; }

        [XmlAttribute(AttributeName = "SpreadScaleMax")]
        public Single SpreadScaleMax { get; set; }

        [XmlAttribute(AttributeName = "SpreadScaleInterpNeg")]
        public Single SpreadScaleInterpNeg { get; set; }

        [XmlAttribute(AttributeName = "SpreadScaleInterpPos")]
        public Single SpreadScaleInterpPos { get; set; }

        [XmlAttribute(AttributeName = "SpreadAlphaInterpNeg")]
        public Single SpreadAlphaInterpNeg { get; set; }

        [XmlAttribute(AttributeName = "SpreadAlphaInterpPos")]
        public Single SpreadAlphaInterpPos { get; set; }

        [XmlAttribute(AttributeName = "HiddenAlphaInterpNeg")]
        public Single HiddenAlphaInterpNeg { get; set; }

        [XmlAttribute(AttributeName = "MoveAlphaMinimum")]
        public Single MoveAlphaMinimum { get; set; }

        [XmlAttribute(AttributeName = "MoveAlphaRange")]
        public Single MoveAlphaRange { get; set; }

    }
}
