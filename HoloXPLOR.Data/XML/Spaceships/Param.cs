using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.Xml.Spaceships
{
    [XmlRoot(ElementName = "param")]
    public partial class Param
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public String Value { get; set; }
    }
}
