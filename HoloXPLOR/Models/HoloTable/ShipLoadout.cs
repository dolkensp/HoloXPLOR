using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory = HoloXPLOR.Data.XML.Inventory;
using Ships = HoloXPLOR.Data.XML.Vehicles.Implementations;
using Items = HoloXPLOR.Data.XML.Spaceships;
using Xml = HoloXPLOR.Data.XML;
using HoloXPLOR.Data;

namespace HoloXPLOR.Models.HoloTable
{
    public partial class ShipLoadout
    {
        public Items.Item[] Weapons { get; set; }
        public Items.Item[] Shields { get; set; }
        public Items.Item[] Armor { get; set; }

        public ShipLoadout(Inventory.Ship ship)
        {
            
        }

        public ShipLoadout(Ships.Vehicle ship)
        {
            var loadout = Scripts.Loadout[ship.Name];

        }

        private IEnumerable<Inventory.Port> Flatten(IEnumerable<Inventory.Port> ports)
        {
            foreach (var port in ports)
            {
                yield return port;
            }
        }
    }
}