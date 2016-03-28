using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SCItemSuitThrusterPackParams")]
    public partial class SCItemSuitThrusterPackParams : SCItemComponentParams
    {
        [XmlElement(ElementName = "StartAudioTrigger")]
        public GlobalResourceAudio StartAudioTrigger { get; set; }

        [XmlElement(ElementName = "StopAudioTrigger")]
        public GlobalResourceAudio StopAudioTrigger { get; set; }

        [XmlArray(ElementName = "Thrusters")]
        [XmlArrayItem(Type = typeof(SCItemSuitThrusterParams))]
        public SCItemSuitThrusterParams[] Thrusters { get; set; }

        [XmlAttribute(AttributeName = "ThrusterFXThreshold")]
        public Single ThrusterFXThreshold { get; set; }

        [XmlAttribute(AttributeName = "ThrusterFXSmoothingTime")]
        public Single ThrusterFXSmoothingTime { get; set; }

    }
}
