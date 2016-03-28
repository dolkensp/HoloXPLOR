using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "TPSInputStringValue")]
    public partial class TPSInputStringValue : TPSInput
    {
        [XmlAttribute(AttributeName = "value")]
        public String Value { get; set; }

    }
}
