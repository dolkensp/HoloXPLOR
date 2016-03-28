using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "UIGraph_HoloTableComponent")]
    public partial class UIGraph_HoloTableComponent : CtxGraph_Component
    {
        [XmlAttribute(AttributeName = "mouseControlComponent")]
        public String MouseControlComponent { get; set; }

    }
}
