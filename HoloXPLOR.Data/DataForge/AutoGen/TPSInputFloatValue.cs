using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "TPSInputFloatValue")]
    public partial class TPSInputFloatValue : TPSInput
    {
        [XmlAttribute(AttributeName = "value")]
        public Single Value { get; set; }

    }
}
