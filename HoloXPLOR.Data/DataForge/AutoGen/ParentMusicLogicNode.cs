using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ParentMusicLogicNode")]
    public partial class ParentMusicLogicNode : MusicLogicNode
    {
        [XmlArray(ElementName = "children")]
        [XmlArrayItem(ElementName = "WeakPointer", Type=typeof(_WeakPointer))]
        public _WeakPointer[] Children { get; set; }

    }
}
