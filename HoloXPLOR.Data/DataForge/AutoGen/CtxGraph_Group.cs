using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CtxGraph_Group")]
    public partial class CtxGraph_Group : CtxGraph_Node
    {
        [XmlArray(ElementName = "contexts")]
        [XmlArrayItem(Type = typeof(CtxGraph_Context))]
        [XmlArrayItem(Type = typeof(UIGraph_Context))]
        public String[] Contexts { get; set; }

    }
}
