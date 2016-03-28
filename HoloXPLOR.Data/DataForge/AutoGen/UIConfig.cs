using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "UIConfig")]
    public partial class UIConfig
    {
        [XmlElement(ElementName = "VisorCurvature")]
        public Visor_Curvature VisorCurvature { get; set; }

        [XmlElement(ElementName = "FPSReticleConfig")]
        public FPSReticle_Config FPSReticleConfig { get; set; }

        [XmlElement(ElementName = "DFM_CriticalInfo")]
        public DFMCriticalInfo_Config DFM_CriticalInfo { get; set; }

        [XmlElement(ElementName = "DFM_ScoreMessage")]
        public DFMScoreMessage_Config DFM_ScoreMessage { get; set; }

        [XmlElement(ElementName = "DamageColours")]
        public Flash_Palette DamageColours { get; set; }

        [XmlArray(ElementName = "Localization")]
        [XmlArrayItem(Type = typeof(LocalizationData))]
        public LocalizationData[] Localization { get; set; }

        [XmlElement(ElementName = "InnerThought")]
        public InnerThought_Config InnerThought { get; set; }

        [XmlAttribute(AttributeName = "ConversationConfig")]
        public Guid ConversationConfig { get; set; }

        [XmlAttribute(AttributeName = "QuantumPOICircleInterpFactor")]
        public Single QuantumPOICircleInterpFactor { get; set; }

    }
}
