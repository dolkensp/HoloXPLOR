using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "UIGraph_ChatComponent")]
    public partial class UIGraph_ChatComponent : CtxGraph_Component
    {
        [XmlAttribute(AttributeName = "chatWidget")]
        public String ChatWidget { get; set; }

    }
}
