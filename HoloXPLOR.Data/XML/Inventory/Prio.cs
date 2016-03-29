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
    [XmlRoot(ElementName = "Prio")]
    public class Prio
    {
        [XmlAttribute(AttributeName = "Value")]
        [DefaultValue("")]
        public String Value { get; set; }
    }
}