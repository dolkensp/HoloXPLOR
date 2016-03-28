using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "TPSInputBoolValue")]
    public partial class TPSInputBoolValue : TPSInput
    {
        [XmlAttribute(AttributeName = "value")]
        public Boolean Value { get; set; }

    }
}
