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
    [XmlRoot(ElementName = "ports")]
    public class PortCollection : XmlCollection<Port>
    {
        [XmlElement(ElementName = "port")]
        public override Port[] Items { get; set; }
    }
}