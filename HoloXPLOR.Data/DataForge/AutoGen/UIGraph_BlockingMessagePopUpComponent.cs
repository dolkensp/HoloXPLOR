using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "UIGraph_BlockingMessagePopUpComponent")]
    public partial class UIGraph_BlockingMessagePopUpComponent : CtxGraph_Component
    {
        [XmlAttribute(AttributeName = "errorFormat")]
        public String ErrorFormat { get; set; }

        [XmlAttribute(AttributeName = "provider")]
        public UIGraph_BlockingMessagePopUpProvider Provider { get; set; }

    }
}
