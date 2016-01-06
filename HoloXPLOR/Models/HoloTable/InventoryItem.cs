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
        public Inventory.Item Inventory_Item { get; set; }
        public Inventory.Ship Inventory_Ship { get; set; }
        public Inventory.Item Inventory_EquippedItem { get; set; }
        public Inventory.Port Inventory_EquippedPort { get; set; }

        public override String ToString()
        {
            return this.Inventory_Item.ToString();
        }

        public Items.Item GameData_Item { get; set; }
        public Items.Item GameData_EquippedItem { get; set; }
        public Ships.Vehicle GameData_Ship { get; set; }

        public Data.XML.ItemPort GameData_EquippedPort { get; set; }
    }
}