using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "UIGraph_MarkerARProviderComponent")]
    public partial class UIGraph_MarkerARProviderComponent : CtxGraph_Component
    {
        [XmlAttribute(AttributeName = "Dock")]
        public String Dock { get; set; }

    }
}
