using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CtxGraph_Dependency")]
    public partial class CtxGraph_Dependency
    {
        [XmlAttribute(AttributeName = "reason")]
        public CtxGraph_ContextActionType Reason { get; set; }

        [XmlAttribute(AttributeName = "first")]
        public String First { get; set; }

        [XmlAttribute(AttributeName = "second")]
        public String Second { get; set; }

    }
}
