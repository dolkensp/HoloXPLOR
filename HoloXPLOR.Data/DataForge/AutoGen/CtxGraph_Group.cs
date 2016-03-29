using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CtxGraph_Group")]
    public partial class CtxGraph_Group : CtxGraph_Node
    {
        [XmlArray(ElementName = "contexts")]
        [XmlArrayItem(ElementName = "WeakPointer", Type=typeof(_WeakPointer))]
        public _WeakPointer[] Contexts { get; set; }

    }
}
