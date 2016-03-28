using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "UIGraph_MarkerARDockComponent")]
    public partial class UIGraph_MarkerARDockComponent : CtxGraph_Component
    {
        [XmlAttribute(AttributeName = "dockingStation")]
        public String DockingStation { get; set; }

    }
}
