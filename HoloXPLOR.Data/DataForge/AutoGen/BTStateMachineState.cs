using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTStateMachineState")]
    public partial class BTStateMachineState : BTElement
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlArray(ElementName = "transitions")]
        [XmlArrayItem(Type = typeof(BTTransition))]
        public BTTransition[] Transitions { get; set; }

        [XmlAttribute(AttributeName = "child")]
        public String Child { get; set; }

    }
}
