using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "UIGraph_ContactWidgetComponent")]
    public partial class UIGraph_ContactWidgetComponent : CtxGraph_Component
    {
        [XmlAttribute(AttributeName = "dockingStation")]
        public String DockingStation { get; set; }

    }
}
