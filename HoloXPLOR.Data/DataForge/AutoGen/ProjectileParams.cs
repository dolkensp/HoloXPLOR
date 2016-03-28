using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ProjectileParams")]
    public partial class ProjectileParams
    {
        [XmlArray(ElementName = "detonationParams")]
        [XmlArrayItem(Type = typeof(ProjectileDetonationParams))]
        public ProjectileDetonationParams[] DetonationParams { get; set; }

    }
}
