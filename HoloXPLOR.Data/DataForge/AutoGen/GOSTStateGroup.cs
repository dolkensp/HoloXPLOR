using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "GOSTStateGroup")]
    public partial class GOSTStateGroup
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "history")]
        public Boolean History { get; set; }

        [XmlAttribute(AttributeName = "tags")]
        public String Tags { get; set; }

        [XmlArray(ElementName = "Variables")]
        [XmlArrayItem(Type = typeof(GOSTVariable))]
        public GOSTVariable[] Variables { get; set; }

        [XmlArray(ElementName = "States")]
        [XmlArrayItem(Type = typeof(GOSTState))]
        public GOSTState[] States { get; set; }

    }
}
