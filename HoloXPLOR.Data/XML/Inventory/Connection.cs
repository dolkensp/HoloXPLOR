using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.XML.Inventory
{
    [XmlRoot(ElementName = "connection")]
    public class Connection
    {
        [XmlAttribute(AttributeName = "pipeClass")]
        [DefaultValue("")]
        public String PipeClass { get; set; }

        [XmlAttribute(AttributeName = "pipe")]
        [DefaultValue("")]
        public String Pipe { get; set; }

        [XmlElement(ElementName = "PrioGroup")]
        public PrioCollection PrioGroup { get; set; }
    }
}