using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.XML.Vehicles.Implementations
{
    [XmlRoot(ElementName = "Modification")]
    public class Modification
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "patchFile")]
        public String PatchFile { get; set; }

        [XmlArray(ElementName = "Elems")]
        [XmlArrayItem(ElementName = "Elem")]
        public Element[] Elements { get; set; }

        [XmlArray(ElementName = "Parts")]
        [XmlArrayItem(ElementName = "Part")]
        public Part[] Parts { get; set; }
    }
}
