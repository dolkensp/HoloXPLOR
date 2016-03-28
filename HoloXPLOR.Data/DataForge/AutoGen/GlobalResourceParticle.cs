using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "GlobalResourceParticle")]
    public partial class GlobalResourceParticle : GlobalResourceBase
    {
        [XmlAttribute(AttributeName = "path")]
        public String Path { get; set; }

    }
}
