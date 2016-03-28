using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "UIGraph_ARModeComponent")]
    public partial class UIGraph_ARModeComponent : CtxGraph_Component
    {
        [XmlAttribute(AttributeName = "queryAndFocus")]
        public String QueryAndFocus { get; set; }

    }
}
