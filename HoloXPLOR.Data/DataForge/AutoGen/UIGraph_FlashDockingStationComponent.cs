using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "UIGraph_FlashDockingStationComponent")]
    public partial class UIGraph_FlashDockingStationComponent : CtxGraph_Component
    {
        [XmlAttribute(AttributeName = "displayName")]
        public String DisplayName { get; set; }

    }
}
