using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ExplosionFlashbangParams")]
    public partial class ExplosionFlashbangParams
    {
        [XmlAttribute(AttributeName = "blindAmount")]
        public Single BlindAmount { get; set; }

        [XmlAttribute(AttributeName = "flashbangBaseTime")]
        public Single FlashbangBaseTime { get; set; }

    }
}
