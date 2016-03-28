using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "UIGraph_MouseControlComponent")]
    public partial class UIGraph_MouseControlComponent : CtxGraph_Component
    {
        [XmlAttribute(AttributeName = "autoHandleInput")]
        public Boolean AutoHandleInput { get; set; }

    }
}
