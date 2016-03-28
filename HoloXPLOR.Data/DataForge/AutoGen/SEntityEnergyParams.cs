using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SEntityEnergyParams")]
    public partial class SEntityEnergyParams
    {
        [XmlArray(ElementName = "PipeConnections")]
        [XmlArrayItem(Type = typeof(SPipeConnection))]
        public SPipeConnection[] PipeConnections { get; set; }

        [XmlElement(ElementName = "Distortion")]
        public SPipeDistortion Distortion { get; set; }

    }
}
