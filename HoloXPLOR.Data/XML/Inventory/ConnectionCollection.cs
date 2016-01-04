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
    [XmlRoot(ElementName = "pipes")]
    public class ConnectionCollection : XmlCollection<Connection>
    {
        [XmlElement(ElementName = "connection")]
        public override Connection[] Items { get; set; }
    }
}