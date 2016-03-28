using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SCItemShieldGeneratorParams")]
    public partial class SCItemShieldGeneratorParams : SCItemComponentParams
    {
        [XmlElement(ElementName = "ShieldEmitterContributions")]
        public SShieldEmitterContributions ShieldEmitterContributions { get; set; }

    }
}
