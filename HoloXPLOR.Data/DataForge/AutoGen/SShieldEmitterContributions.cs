using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SShieldEmitterContributions")]
    public partial class SShieldEmitterContributions
    {
        [XmlAttribute(AttributeName = "MaxShieldHealth")]
        public Single MaxShieldHealth { get; set; }

        [XmlAttribute(AttributeName = "MaxShieldRegen")]
        public Single MaxShieldRegen { get; set; }

    }
}
