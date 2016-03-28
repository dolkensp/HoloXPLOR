using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "UIGraph_MissionMgrComponent")]
    public partial class UIGraph_MissionMgrComponent : CtxGraph_Component
    {
        [XmlAttribute(AttributeName = "dockingStation")]
        public String DockingStation { get; set; }

        [XmlAttribute(AttributeName = "dockComponent")]
        public String DockComponent { get; set; }

    }
}
