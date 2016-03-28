using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "UIGraph_ShopComponent")]
    public partial class UIGraph_ShopComponent : CtxGraph_Component
    {
        [XmlAttribute(AttributeName = "dockingStation")]
        public String DockingStation { get; set; }

    }
}
