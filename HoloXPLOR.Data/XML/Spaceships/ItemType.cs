using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.XML.Spaceships
{
    [XmlRoot(ElementName = "Type")]
    public partial class ItemType
    {
        [XmlAttribute(AttributeName = "type")]
        public String Type { get; set; }

        [XmlAttribute(AttributeName = "subtypes")]
        public String SubType { get; set; }
    }
}
