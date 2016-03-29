using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.Xml.Inventory
{
    [XmlRoot(ElementName = "pipe")]
    public class Pipe
    {
        [XmlAttribute(AttributeName = "name")]
        [DefaultValue("")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "class")]
        [DefaultValue("")]
        public String Class { get; set; }

        [XmlAttribute(AttributeName = "priority")]
        [DefaultValue(0)]
        public Int32 Priority { get; set; }

        [XmlAttribute(AttributeName = "type")]
        [DefaultValue(0)]
        public Int32 Type { get; set; }
    }
}