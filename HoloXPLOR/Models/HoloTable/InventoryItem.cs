using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory = HoloXPLOR.Data.XML.Inventory;
using Ships = HoloXPLOR.Data.XML.Vehicles.Implementations;
using Items = HoloXPLOR.Data.XML.Spaceships;

namespace HoloXPLOR.Models.HoloTable
{
    public class InventoryItem
    {
        public Inventory.Item BaseItem { get; set; }
        public Inventory.Ship BaseShip { get; set; }
        public Inventory.Item EquippedItem { get; set; }
        public Inventory.Port EquippedPort { get; set; }

        public override String ToString()
        {
            return this.BaseItem.ToString();
        }
    }
}