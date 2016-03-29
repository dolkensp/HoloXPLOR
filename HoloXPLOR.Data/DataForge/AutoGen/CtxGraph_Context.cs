using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CtxGraph_Context")]
    public partial class CtxGraph_Context : CtxGraph_Node
    {
        [XmlArray(ElementName = "dependencies")]
        [XmlArrayItem(Type = typeof(CtxGraph_Dependency))]
        public CtxGraph_Dependency[] Dependencies { get; set; }

        [XmlArray(ElementName = "components")]
        [XmlArrayItem(ElementName = "WeakPointer", Type=typeof(_WeakPointer))]
        public _WeakPointer[] Components { get; set; }

    }
}
