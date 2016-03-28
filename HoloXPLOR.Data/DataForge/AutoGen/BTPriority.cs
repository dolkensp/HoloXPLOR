using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTPriority")]
    public partial class BTPriority : BTNode
    {
        [XmlArray(ElementName = "children")]
        [XmlArrayItem(Type = typeof(BTPriorityChild))]
        [XmlArrayItem(Type = typeof(BTPriorityCondition))]
        [XmlArrayItem(Type = typeof(BTPriorityDefault))]
        public String[] Children { get; set; }

    }
}
