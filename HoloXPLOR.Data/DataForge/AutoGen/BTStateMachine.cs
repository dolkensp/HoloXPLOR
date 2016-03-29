using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTStateMachine")]
    public partial class BTStateMachine : BTNode
    {
        [XmlArray(ElementName = "states")]
        [XmlArrayItem(ElementName = "WeakPointer", Type=typeof(_WeakPointer))]
        public _WeakPointer[] States { get; set; }

    }
}
