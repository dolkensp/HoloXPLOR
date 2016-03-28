using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "GOSTEntityStateMachine")]
    public partial class GOSTEntityStateMachine
    {
        [XmlArray(ElementName = "GOSTs")]
        [XmlArrayItem(Type = typeof(GOSTInstance))]
        public GOSTInstance[] GOSTs { get; set; }

    }
}
