using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SPipeSignal")]
    public partial class SPipeSignal
    {
        [XmlAttribute(AttributeName = "SignalPerRequestValue")]
        public Single SignalPerRequestValue { get; set; }

        [XmlAttribute(AttributeName = "SignalPerPoolValue")]
        public Single SignalPerPoolValue { get; set; }

        [XmlAttribute(AttributeName = "SignalType")]
        public ESignalTypes SignalType { get; set; }

    }
}
