using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CounterMeasureFlareParams")]
    public partial class CounterMeasureFlareParams : CounterMeasureBaseParams
    {
        [XmlAttribute(AttributeName = "StartInfrared")]
        public Single StartInfrared { get; set; }

        [XmlAttribute(AttributeName = "StartElectromagnetic")]
        public Single StartElectromagnetic { get; set; }

        [XmlAttribute(AttributeName = "StartCrossSection")]
        public Single StartCrossSection { get; set; }

        [XmlAttribute(AttributeName = "StartDecibel")]
        public Single StartDecibel { get; set; }

        [XmlAttribute(AttributeName = "EndInfrared")]
        public Single EndInfrared { get; set; }

        [XmlAttribute(AttributeName = "EndElectromagnetic")]
        public Single EndElectromagnetic { get; set; }

        [XmlAttribute(AttributeName = "EndCrossSection")]
        public Single EndCrossSection { get; set; }

        [XmlAttribute(AttributeName = "EndDecibel")]
        public Single EndDecibel { get; set; }

    }
}
