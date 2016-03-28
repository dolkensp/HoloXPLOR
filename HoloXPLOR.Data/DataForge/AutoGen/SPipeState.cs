using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SPipeState")]
    public partial class SPipeState
    {
        [XmlAttribute(AttributeName = "Name")]
        public String Name { get; set; }

        [XmlArray(ElementName = "Values")]
        [XmlArrayItem(Type = typeof(SPipeStateValue))]
        public SPipeStateValue[] Values { get; set; }

        [XmlAttribute(AttributeName = "Transition")]
        public Single Transition { get; set; }

    }
}
