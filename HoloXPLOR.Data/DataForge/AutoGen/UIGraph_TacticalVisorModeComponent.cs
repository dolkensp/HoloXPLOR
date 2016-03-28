using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "UIGraph_TacticalVisorModeComponent")]
    public partial class UIGraph_TacticalVisorModeComponent : CtxGraph_Component
    {
        [XmlAttribute(AttributeName = "queryAndFocus")]
        public String QueryAndFocus { get; set; }

    }
}
