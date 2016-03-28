using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SCItemShieldEmitterParams")]
    public partial class SCItemShieldEmitterParams : SCItemComponentParams
    {
        [XmlElement(ElementName = "Data")]
        public SShieldData Data { get; set; }

    }
}
