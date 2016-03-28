using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "DFMCriticalInfo_Notify")]
    public partial class DFMCriticalInfo_Notify
    {
        [XmlAttribute(AttributeName = "Text")]
        public String Text { get; set; }

        [XmlAttribute(AttributeName = "Priority")]
        public Byte Priority { get; set; }

    }
}
