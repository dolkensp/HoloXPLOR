using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "GOSTInstance")]
    public partial class GOSTInstance
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlArray(ElementName = "Constants")]
        [XmlArrayItem(Type = typeof(GOSTConstant))]
        public GOSTConstant[] Constants { get; set; }

        [XmlArray(ElementName = "StateGroups")]
        [XmlArrayItem(Type = typeof(GOSTStateGroupImport))]
        public GOSTStateGroupImport[] StateGroups { get; set; }

    }
}
