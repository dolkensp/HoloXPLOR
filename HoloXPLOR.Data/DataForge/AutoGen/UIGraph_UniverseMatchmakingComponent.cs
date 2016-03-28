using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "UIGraph_UniverseMatchmakingComponent")]
    public partial class UIGraph_UniverseMatchmakingComponent : CtxGraph_Component
    {
        [XmlAttribute(AttributeName = "mouseControlComponent")]
        public String MouseControlComponent { get; set; }

    }
}
