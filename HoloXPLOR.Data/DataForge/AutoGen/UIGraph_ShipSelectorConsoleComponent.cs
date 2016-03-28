using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "UIGraph_ShipSelectorConsoleComponent")]
    public partial class UIGraph_ShipSelectorConsoleComponent : CtxGraph_Component
    {
        [XmlAttribute(AttributeName = "mouseControlComponent")]
        public String MouseControlComponent { get; set; }

    }
}
