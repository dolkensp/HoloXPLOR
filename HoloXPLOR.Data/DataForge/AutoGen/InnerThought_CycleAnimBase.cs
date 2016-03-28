using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "InnerThought_CycleAnimBase")]
    public partial class InnerThought_CycleAnimBase
    {
        [XmlAttribute(AttributeName = "Length")]
        public Single Length { get; set; }

        [XmlAttribute(AttributeName = "Amount")]
        public Single Amount { get; set; }

        [XmlAttribute(AttributeName = "Stagger")]
        public Single Stagger { get; set; }

    }
}
