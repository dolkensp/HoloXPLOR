using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTPriority")]
    public partial class BTPriority : BTNode
    {
        [XmlArray(ElementName = "children")]
        [XmlArrayItem(ElementName = "WeakPointer", Type=typeof(_WeakPointer))]
        public _WeakPointer[] Children { get; set; }

    }
}
