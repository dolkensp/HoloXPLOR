using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.Xml.Vehicles.Implementations
{
    [XmlRoot(ElementName = "Elem")]
    public class Element
    {
        [XmlAttribute(AttributeName = "idRef")]
        public String IDRef { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public String Value { get; set; }

        [XmlArray(ElementName = "Elems")]
        [XmlArrayItem(ElementName = "Elem")]
        public Element[] Elements { get; set; }
    }
}
