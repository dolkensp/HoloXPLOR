using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "GlobalResourceCGF")]
    public partial class GlobalResourceCGF : GlobalResourceBase
    {
        [XmlAttribute(AttributeName = "path")]
        public String Path { get; set; }

    }
}
