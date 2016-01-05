using HoloXPLOR.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory = HoloXPLOR.Data.XML.Inventory;
using Ships = HoloXPLOR.Data.XML.Vehicles.Implementations;
using Items = HoloXPLOR.Data.XML.Spaceships;
using Xml = HoloXPLOR.Data.XML;

namespace HoloXPLOR.Models.HoloTable
{
    public class DetailModel
    {
        public DetailModel(String id, Guid? shipID = null)
        {
            this._currentXML = id;

            String filename = HttpContext.Current.Server.MapPath(String.Format(@"~/App_Data/{0}.xml", this.CurrentXML));

            if (File.Exists(filename))
            {
                String inXML = System.IO.File.ReadAllText(filename);

                this.Player = inXML.FromXML<Inventory.Player>();
                this.CurrentShipID = shipID;
            }
            else
                throw new FileNotFoundException("Unable to load specified xml", String.Format("{0}.xml", id));
        }

        private Inventory.Player _player;
        public Inventory.Player Player
        {
            get { return this._player; }
            set
            {
                this._gameData_ShipMap = null;
                this._inventory_ItemMap = null;
                this._inventory_ShipMap = null;
                this._currentShipID = null;
                this._player = value;
            }
        }

        private String _currentXML;
        public String CurrentXML
        {
            get { return this._currentXML; }
        }

        private Guid? _currentShipID;
        public Guid? CurrentShipID
        {
            get { return this._currentShipID = this._currentShipID ?? this.Player.VehicleID; }
            set { this._currentShipID = value; }
        }

        public Inventory.Ship CurrentShip
        {
            get { return this.Inventory_ShipMap.GetValue(this.CurrentShipID ?? Guid.Empty, null); }
        }

        public List<Xml.ItemPort> Loadout
        {
            get { return this.GameData_Hardpoints.GetValue(this.CurrentShipID ?? Guid.Empty, new List<Xml.ItemPort> { }); }
        }

        #region ViewModel

        private Dictionary<Guid, InventoryItem> _inventory;
        public Dictionary<Guid, InventoryItem> Inventory
        {
            get
            {
                var itemPorts = (from item in this.Player.Items
                                 where item.Ports.Items != null
                                 from port in item.Ports.Items
                                 select new { Item = item, Port = port });

                var shipPorts = (from ship in this.Player.Ships
                                 where ship.Ports.Items != null
                                 from port in ship.Ports.Items
                                 select new { Ship = ship, Port = port });

                var itemShips = (from ship in this.Player.Ships
                                 where ship.Inventory.Items != null
                                 from item in ship.Inventory.Items
                                 select new { Ship = ship, Item = item });

                return this._inventory = this._inventory ??
                        (from self in this.Player.Items
                         join item2 in itemPorts on self.ID equals item2.Port.ItemID into ports
                         from port1 in ports.DefaultIfEmpty()
                         join item3 in itemShips on self.ID equals item3.Item.ID into ships
                         from ship1 in ships.DefaultIfEmpty()
                         let shipID = ((ship1 != null) && (ship1.Ship != null) ? ship1.Ship.ID : Guid.Empty)
                         join item4 in shipPorts on shipID equals item4.Ship.ID into ports2
                         from port2 in ports2.DefaultIfEmpty()
                         let port = (port1 != null ? port1.Port : null) ?? (port2 != null ? port2.Port : null)
                         let ship = (ship1 != null ? ship1.Ship : null)
                         let item = (port1 != null ? port1.Item : null)
                         let inventoryItem = new InventoryItem
                         {
                             BaseItem = self,
                             BaseShip = ship,
                             EquippedItem = item,
                             EquippedPort = port
                         }
                         group inventoryItem by inventoryItem.BaseItem.ID into groupedItems
                         select groupedItems.First()).ToDictionary(k => k.BaseItem.ID, v => v);
            }
        }

        #endregion

        #region Inventory

        private Dictionary<Guid, Inventory.Item> _inventory_ItemMap;
        public Dictionary<Guid, Inventory.Item> Inventory_ItemMap
        {
            get { return this._inventory_ItemMap = this._inventory_ItemMap ?? this.Player.Items.ToDictionary(k => k.ID, v => v); }
            set { this._inventory_ItemMap = value; }
        }

        private Dictionary<Guid, Dictionary<Guid, Inventory.Item>> _inventory_ManufacturerMap;
        public Dictionary<Guid, Dictionary<Guid, Inventory.Item>> Inventory_ManufacturerMap
        {
            get
            {
                return this._inventory_ManufacturerMap = this._inventory_ManufacturerMap ??
                    (from item in this.Player.Items
                     group item by item.ManufacturerID into groupedItems
                     select new
                     {
                         Key = groupedItems.Key,
                         Value = groupedItems.ToDictionary(k => k.ID, v => v)
                     }).ToDictionary(k => k.Key, v => v.Value);
            }
            set { this._inventory_ManufacturerMap = value; }
        }

        private Dictionary<Guid, Inventory.Ship> _inventory_ShipMap;
        public Dictionary<Guid, Inventory.Ship> Inventory_ShipMap
        {
            get { return this._inventory_ShipMap = this._inventory_ShipMap ?? this.Player.Ships.ToDictionary(k => k.ID, v => v); }
            set { this._inventory_ShipMap = value; }
        }

        #endregion

        #region Game Data

        private Dictionary<Guid, Ships.Vehicle> _gameData_ShipMap;
        public Dictionary<Guid, Ships.Vehicle> GameData_ShipMap
        {
            get
            {
                return this._gameData_ShipMap = this._gameData_ShipMap ??
                    (from ship in this.Inventory_ShipMap.Values
                     let shipName = ship.Class.Split('.').Last()
                     let vehicle = Scripts.Vehicles.GetValue(shipName, null)
                     let parts = shipName.Split('_')
                     let shipBase = String.Join("_", parts.Take(Math.Min(parts.Length - 1, 1)))
                     let vehicle2 = vehicle ?? Scripts.Vehicles.GetValue(shipBase, null)
                     where vehicle2 != null
                     where vehicle2.Name != "GRIN_PTV"
                     orderby vehicle2.DisplayName
                     select new 
                     {
                         Key = ship.ID,
                         Value = vehicle2
                     }).ToDictionary(k => k.Key, v => v.Value);
            }
        }

        public Dictionary<Guid, Items.Item> _gameData_ItemMap;
        public Dictionary<Guid, Items.Item> GameData_ItemMap
        {
            get
            {
                return this._gameData_ItemMap = this._gameData_ItemMap ??
                    (from item in this.Inventory_ItemMap.Values
                     let part = Scripts.Items.GetValue(item.Class, null)
                     where part != null
                     orderby Scripts.Localization.GetValue(part.DisplayName, part.DisplayName)
                     select new
                     {
                         Key = item.ID,
                         Value = part
                     }).ToDictionary(k => k.Key, v => v.Value);
            }
        }

        private Dictionary<Items.CategoryEnum, Dictionary<Guid, Items.Item>> _gameData_CategoryMap;
        public Dictionary<Items.CategoryEnum, Dictionary<Guid, Items.Item>> GameData_CategoryMap
        {
            get
            {
                if (this._gameData_CategoryMap == null)
                {
                    var allKeys = Enum.GetValues(typeof(Items.CategoryEnum)).OfType<Items.CategoryEnum>();

                    this._gameData_CategoryMap = this._gameData_CategoryMap ??
                        (from item in this.Inventory_ItemMap.Values
                         let part = Scripts.Items.GetValue(item.Class, null)
                         where part != null
                         orderby Scripts.Localization.GetValue(part.DisplayName, part.DisplayName)
                         let lookup = new
                         {
                             ID = item.ID,
                             Part = part,
                             Category = part.ItemCategory
                         }
                         group lookup by lookup.Category into groupedItems
                         select new
                         {
                             Key = groupedItems.Key,
                             Value = groupedItems.ToDictionary(k => k.ID, v => v.Part)
                         }).ToDictionary(k => k.Key, v => v.Value);

                    foreach (var missingKey in allKeys.Except(this._gameData_CategoryMap.Keys))
                        this._gameData_CategoryMap[missingKey] = new Dictionary<Guid,Items.Item>();
                }

                return this._gameData_CategoryMap;
            }
        }

        private Dictionary<Guid, List<Xml.ItemPort>> _gameData_Hardpoints;
        public Dictionary<Guid, List<Xml.ItemPort>> GameData_Hardpoints
        {
            get
            {
                var shipPorts = (from kvp in this.GameData_ShipMap
                                 let ship = kvp.Value
                                 let id = kvp.Key
                                 from shipPart in ship.Parts
                                 from part in this.GetParts(shipPart)
                                 from port in part.ItemPorts
                                 let temp = port.Name = part.Name
                                 select new KeyValuePair<Guid, Xml.ItemPort>(id, port));
                var itemPorts = (from kvp in this.GameData_ItemMap
                                 let item = kvp.Value
                                 let id = kvp.Key
                                 where item.PortParams != null
                                 from port in item.PortParams.Items
                                 select new KeyValuePair<Guid, Xml.ItemPort>(id, port));

                return this._gameData_Hardpoints = this._gameData_Hardpoints ??
                    (from port in shipPorts.Union(itemPorts)
                     orderby port.Value.DisplayName
                     group port by port.Key into groupedItems
                     select groupedItems).ToDictionary(k => k.Key, v => v.Select(s => s.Value).ToList());
            }
        }

        private static HashSet<String> _validTypes = new HashSet<String>
        {
            "Shield",
            "Armor",
            "Turret",
            "WeaponGun",
            "WeaponMissile",
            "MainThruster",
            "PowerPlant",
            "ManneuverThruster", // Maneuvering Thrusters
            "TurretBase",
            "Paints",
            
            // "Player",            // Player
            // "WeaponDefensive",   // Counter Measures
            // "Seat",              // Seats

            // "Cooler",
            // "FuelIntake",
            // "FuelTank",
            // "SelfDestruct",
            // "MultiLight",
            // "Avionics",
            // "Radar",
            // "Display",
            // "Light",
            // "QuantumFuelTank",
            // "LandingSystem",
            // "Audio",
            // "Interior",
        };

        private IEnumerable<Ships.Part> GetParts(Ships.Part parent)
        {
            if (parent.Parts != null)
                foreach (var part in parent.Parts.SelectMany(p => this.GetParts(p)))
                    yield return part;

            if ((from itemPort in parent.ItemPorts ?? new Xml.ItemPort[] { }
                    from type in itemPort.Types ?? new Xml.ItemType[] { }
                    where _validTypes.Contains(type.Type)
                    select true).Any())
                yield return parent;
        }

        #endregion
    }
}
