using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "GlobalResourceMaterial")]
    public partial class GlobalResourceMaterial : GlobalResourceBase
    {
        [XmlAttribute(AttributeName = "path")]
        public String Path { get; set; }

    }
}
