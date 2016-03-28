using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "UIGraph_ControllerComponent")]
    public partial class UIGraph_ControllerComponent : CtxGraph_Component
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

    }
}
