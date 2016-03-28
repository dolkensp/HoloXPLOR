using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "UIGraph_SimpleComponent")]
    public partial class UIGraph_SimpleComponent : CtxGraph_Component
    {
        [XmlAttribute(AttributeName = "type")]
        public UIGraph_SimpleComponentType Type { get; set; }

    }
}
