using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "TPSInputIntValue")]
    public partial class TPSInputIntValue : TPSInput
    {
        [XmlAttribute(AttributeName = "value")]
        public Int32 Value { get; set; }

    }
}
