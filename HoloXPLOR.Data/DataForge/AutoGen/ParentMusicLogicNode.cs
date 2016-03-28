using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ParentMusicLogicNode")]
    public partial class ParentMusicLogicNode : MusicLogicNode
    {
        [XmlArray(ElementName = "children")]
        [XmlArrayItem(Type = typeof(MusicLogicNode))]
        [XmlArrayItem(Type = typeof(ParentMusicLogicNode))]
        [XmlArrayItem(Type = typeof(MusicLogicParameterMultiply))]
        [XmlArrayItem(Type = typeof(MusicLogicIncrement))]
        [XmlArrayItem(Type = typeof(MusicLogicSetValue))]
        [XmlArrayItem(Type = typeof(MusicLogicTrigger))]
        [XmlArrayItem(Type = typeof(MusicLogicSwitch))]
        [XmlArrayItem(Type = typeof(MusicLogicCondition))]
        [XmlArrayItem(Type = typeof(GreaterThan))]
        [XmlArrayItem(Type = typeof(MusicEventResponse))]
        public String[] Children { get; set; }

    }
}
