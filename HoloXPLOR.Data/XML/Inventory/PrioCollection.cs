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
    [XmlRoot(ElementName = "PrioGroup")]
    public class PrioCollection : XmlCollection<Prio>
    {
        [XmlElement(ElementName = "Prio")]
        public override Prio[] Items { get; set; }
    }
}