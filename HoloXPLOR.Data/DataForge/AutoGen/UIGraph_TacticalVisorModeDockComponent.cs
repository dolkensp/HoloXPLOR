using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "UIGraph_TacticalVisorModeDockComponent")]
    public partial class UIGraph_TacticalVisorModeDockComponent : CtxGraph_Component
    {
        [XmlAttribute(AttributeName = "queryAndFocus")]
        public String QueryAndFocus { get; set; }

        [XmlAttribute(AttributeName = "dockingStation")]
        public String DockingStation { get; set; }

    }
}
