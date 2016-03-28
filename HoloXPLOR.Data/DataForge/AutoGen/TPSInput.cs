using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "TPSInput")]
    public partial class TPSInput
    {
        [XmlAttribute(AttributeName = "condition")]
        public String Condition { get; set; }

    }
}
