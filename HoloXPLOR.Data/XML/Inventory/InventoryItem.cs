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
    [XmlRoot(ElementName = "item")]
    public class InventoryItem : IComparable<InventoryItem>
    {
        /// <summary>
        /// The ID of the item in the inventory
        /// </summary>
        [XmlAttribute(AttributeName = "__EID__id")]
        public Guid ID { get; set; }

        public Int32 CompareTo(InventoryItem other)
        {
            return this.ID.CompareTo(other.ID);
        }
    }
}