using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTStateMachine")]
    public partial class BTStateMachine : BTNode
    {
        [XmlArray(ElementName = "states")]
        [XmlArrayItem(Type = typeof(BTStateMachineState))]
        public String[] States { get; set; }

    }
}
