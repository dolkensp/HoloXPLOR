using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "UIGraph_FastContactListComponent")]
    public partial class UIGraph_FastContactListComponent : CtxGraph_Component
    {
        [XmlAttribute(AttributeName = "contactWidget")]
        public String ContactWidget { get; set; }

    }
}
