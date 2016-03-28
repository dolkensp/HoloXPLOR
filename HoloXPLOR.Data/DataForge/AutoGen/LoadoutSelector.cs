using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "LoadoutSelector")]
    public partial class LoadoutSelector : StaticEnvironmentItem
    {
        [XmlElement(ElementName = "LoadoutSelectorItemParams")]
        public LoadoutSelectorParams LoadoutSelectorItemParams { get; set; }

    }
}
