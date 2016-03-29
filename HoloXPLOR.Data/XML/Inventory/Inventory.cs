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
    [XmlRoot(ElementName = "inventory")]
    public class Inventory : XmlCollection<InventoryItem>
    {
        [XmlElement(ElementName = "item")]
        public override InventoryItem[] Items { get; set; }
    }
}