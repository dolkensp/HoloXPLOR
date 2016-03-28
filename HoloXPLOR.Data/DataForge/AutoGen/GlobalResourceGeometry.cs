using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "GlobalResourceGeometry")]
    public partial class GlobalResourceGeometry : GlobalResourceBase
    {
        [XmlAttribute(AttributeName = "path")]
        public String Path { get; set; }

    }
}
