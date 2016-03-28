using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "UIGraph_HomeScreenComponent")]
    public partial class UIGraph_HomeScreenComponent : CtxGraph_Component
    {
        [XmlAttribute(AttributeName = "dockingStation")]
        public String DockingStation { get; set; }

        [XmlAttribute(AttributeName = "dockComponent")]
        public String DockComponent { get; set; }

    }
}
