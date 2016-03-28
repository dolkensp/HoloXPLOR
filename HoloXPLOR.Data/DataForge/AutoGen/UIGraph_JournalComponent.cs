using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "UIGraph_JournalComponent")]
    public partial class UIGraph_JournalComponent : CtxGraph_Component
    {
        [XmlAttribute(AttributeName = "dockingStation")]
        public String DockingStation { get; set; }

        [XmlAttribute(AttributeName = "dockComponent")]
        public String DockComponent { get; set; }

    }
}
