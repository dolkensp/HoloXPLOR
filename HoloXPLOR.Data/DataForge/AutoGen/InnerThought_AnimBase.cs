using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "InnerThought_AnimBase")]
    public partial class InnerThought_AnimBase
    {
        [XmlAttribute(AttributeName = "GlyphStagger")]
        public Single GlyphStagger { get; set; }

        [XmlAttribute(AttributeName = "Length")]
        public Single Length { get; set; }

        [XmlAttribute(AttributeName = "RandomStagger")]
        public Boolean RandomStagger { get; set; }

    }
}
