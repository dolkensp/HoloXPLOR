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
using System.Xml;
using System.Xml.Serialization;
using System.Text;

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
                this.Player = System.IO.File.ReadAllText(filename).FromXML<Inventory.Player>();
                this.ShipID = shipID ?? Guid.Empty;
            }
            else
            {
                throw new FileNotFoundException("Unable to load specified xml", String.Format("{0}.xml", id));
            }
        }

        public void Save()
        {
            String filename = HttpContext.Current.Server.MapPath(String.Format(@"~/App_Data/{0}.xml", this.CurrentXML));

            if (File.Exists(filename))
            {
                String backupFilename = Path.ChangeExtension(filename, "bak");

                if (!File.Exists(backupFilename))
                {
                    File.Move(filename, backupFilename);
                }

                XmlSerializer xs = new XmlSerializer(typeof(Inventory.Player));
                XmlTextWriter xw = new XmlTextWriter(filename, Encoding.UTF8);

                xw.Indentation = 1;
                xw.IndentChar = ' ';
                xw.Formatting = Formatting.Indented;

                xw.WriteWhitespace("");
                xs.Serialize(xw, this.Player);
                xw.Close();
            }
        }

        private Inventory.Player _player;
        /// <summary>
        /// Deserialized instance of the currently selected XML file
        /// </summary>
        public Inventory.Player Player
        {
            get { return this._player; }
            set
            {
                this._gameData_ShipMap = null;
                this._inventory_ItemMap = null;
                this._inventory_ShipMap = null;
                this._shipID = null;
                this._player = value;
            }
        }

        /// <summary>
        /// ID of the hangar
        /// </summary>
        private String _currentXML;
        /// <summary>
        /// The XML file that is currently selected
        /// </summary>
        public String CurrentXML
        {
            get { return this._currentXML; }
        }

        private Guid? _shipID;
        /// <summary>
        /// The ID of the currently selected ship
        /// </summary>
        public Guid ShipID
        {
            get { return this._shipID ?? Guid.Empty; } // ?? this.Player.VehicleID; }
            set { this._shipID = value; }
        }

        public Boolean ShowAllItems { get; set; }

        #region Constants

        private static HashSet<String> _invalidNames = new HashSet<String>
        {
            "Power Plant",
            "Turret Slot",
            "Shield Generator",
            "Shield Slot",
        };

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

            "AmmoBox",
            "Ordinance",
        };

        #endregion

        #region ViewModel

        /// <summary>
        /// The items the current ship has equipped
        /// </summary>
        public List<InventoryItem> View_Loadout
        {
            get { return this.View_LoadoutMap.GetValue(this.ShipID, new List<InventoryItem> { }); }
        }

        private Dictionary<Items.CategoryEnum, List<InventoryItem>> _view_CategoryLoadout;
        public Dictionary<Items.CategoryEnum, List<InventoryItem>> View_CategoryLoadout
        {
            get
            {
                if (this._view_CategoryLoadout == null)
                {
                    var allKeys = Enum.GetValues(typeof(Items.CategoryEnum)).OfType<Items.CategoryEnum>();

                    this._view_CategoryLoadout = this._view_CategoryLoadout ??
                        (from item in this.View_Loadout
                         let key = item.GameData_Item == null ? Items.CategoryEnum.__Empty__ : item.GameData_Item.ItemCategory
                         group item by key into groupedItems
                         select groupedItems).ToDictionary(k => k.Key, v => v.ToList());


                    foreach (var missingKey in allKeys.Except(this._view_CategoryLoadout.Keys))
                        this._view_CategoryLoadout[missingKey] = new List<InventoryItem> { };
                }

                return this._view_CategoryLoadout;
            }
        }

        private Dictionary<Guid, InventoryItem> _view_ItemMap;
        /// <summary>
        /// Lookup of all available items
        /// </summary>
        public Dictionary<Guid, InventoryItem> View_ItemMap
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

                return this._view_ItemMap = this._view_ItemMap ??
                        (from self in this.Player.Items
                         join item2 in itemPorts on self.ID equals item2.Port.ItemID into ports
                         from port1 in ports.DefaultIfEmpty()
                         join item3 in itemShips on self.ID equals item3.Item.ID into ships
                         from ship1 in ships.DefaultIfEmpty()
                         let shipID = ((ship1 != null) && (ship1.Ship != null) ? ship1.Ship.ID : Guid.Empty)
                         join item4 in shipPorts on self.ID equals item4.Port.ItemID into ports2
                         from port2 in ports2.DefaultIfEmpty()
                         let port = (port1 != null ? port1.Port : null) ?? (port2 != null ? port2.Port : null)
                         let ship = (ship1 != null ? ship1.Ship : null) ?? (port2 != null ? port2.Ship : null)
                         let item = (port1 != null ? port1.Item : null)

                         where this.ShowAllItems || this.ShipID == Guid.Empty || ship == null || ship.ID == this.ShipID

                         let inventoryItem = new InventoryItem
                         {
                             Inventory_Item = self,
                             Inventory_Ship = ship,
                             Inventory_EquippedItem = item,
                             Inventory_EquippedPort = port,

                             GameData_EquippedItem = item != null ? this.GameData_ItemMap.GetValue(item.ID, null) : null,
                             GameData_EquippedPort = item != null ? this.GameData_PortMap.GetValue(item.ID, null) : null,
                             GameData_Item = self != null ? this.GameData_ItemMap.GetValue(self.ID, null) : null,
                             GameData_Ship = ship != null ? this.GameData_ShipMap.GetValue(ship.ID, null) : null,
                         }
                         group inventoryItem by inventoryItem.Inventory_Item.ID into groupedItems
                         select groupedItems.First()).ToDictionary(k => k.Inventory_Item.ID, v => v);
            }
        }

        private Dictionary<Guid, List<InventoryItem>> _view_LoadoutMap;
        /// <summary>
        /// Lookup of all equipped items
        /// </summary>
        public Dictionary<Guid, List<InventoryItem>> View_LoadoutMap
        {
            get
            {
                if (this._view_LoadoutMap == null)
                {
                    var shipPorts = (from ship in this.Player.Ships
                                     
                                     where this.ShipID == Guid.Empty || this.ShipID == ship.ID
                                     
                                     let gameShip = this.GameData_ShipMap.GetValue(ship.ID, null)
                                     where gameShip != null

                                     where gameShip.Parts != null
                                     from gamePart in this.GameData_PartsMap[ship.ID]

                                     where gamePart.ItemPorts != null
                                     from gamePort in gamePart.ItemPorts

                                     where ship.Ports.Items != null
                                     from shipPort in ship.Ports.Items
                                     where shipPort.PortName == (gamePort.Name ?? gamePart.Name)

                                     let shipItem = this.Inventory_ItemMap.GetValue(shipPort.ItemID, null)
                                     let gameItem = this.GameData_ItemMap.GetValue(shipPort.ItemID, null)

                                     let itemPort = new InventoryItem
                                     {
                                         // Top level has no parent item
                                         Inventory_EquippedItem = null,
                                         GameData_EquippedItem = null,
                                         // Top level parent port
                                         Inventory_EquippedPort = shipPort,
                                         GameData_EquippedPort = gamePort,
                                         // Parent ship
                                         Inventory_Ship = ship,
                                         GameData_Ship = gameShip,
                                         // Child item
                                         Inventory_Item = shipItem,
                                         GameData_Item = gameItem,
                                     }
                                     select itemPort).ToList();

                    this._view_LoadoutMap = (from shipPort in shipPorts
                                             from port in this._GetAttachedItems(shipPort)

                                             #region Cleanup

                                             let hack0 = port.GameData_EquippedPort.DisplayName = DetailModel._invalidNames.Contains(port.GameData_EquippedPort.DisplayName) ? port.GameData_EquippedPort.Name : port.GameData_EquippedPort.DisplayName
                                             let hack1 = port.GameData_EquippedPort.Name = port.GameData_EquippedPort.Name ?? port.Inventory_EquippedPort.PortName
                                             let hack2 = port.GameData_EquippedPort.DisplayName = String.IsNullOrWhiteSpace(port.GameData_EquippedPort.DisplayName) ? port.GameData_EquippedPort.Name.ToLocalized() : port.GameData_EquippedPort.DisplayName
                                             let hack3 = (port.GameData_Item != null) && (port.GameData_Item.DisplayName = String.IsNullOrWhiteSpace(port.GameData_Item.DisplayName) ? port.GameData_Item.Name.ToLocalized() : port.GameData_Item.DisplayName) == String.Empty

                                             #endregion

                                             where port.GameData_EquippedPort.Types != null
                                             where DetailModel._validTypes.Intersect(port.GameData_EquippedPort.Types.Select(t => t.Type)).Any()
                                             group port by port.Inventory_Ship.ID into ship
                                             select ship).ToDictionary(k => k.Key, v => v.ToList());
                }

                return this._view_LoadoutMap;
            }
        }

        private IEnumerable<InventoryItem> _GetAttachedItems(InventoryItem item)
        {
            yield return item;

            if (item.GameData_Item != null && item.GameData_Item.PortParams != null)
            {
                var children = (from gamePort in item.GameData_Item.PortParams.Items
                                from shipPort in item.Inventory_Item.Ports.Items
                                where shipPort.PortName == gamePort.Name

                                let shipItem = this.Inventory_ItemMap.GetValue(shipPort.ItemID, null)
                                let gameItem = this.GameData_ItemMap.GetValue(shipPort.ItemID, null)

                                select new InventoryItem
                                {
                                    // Top level parent item
                                    Inventory_EquippedItem = item.Inventory_Item,
                                    GameData_EquippedItem = item.GameData_Item,
                                    // Top level parent port
                                    Inventory_EquippedPort = shipPort,
                                    GameData_EquippedPort = gamePort,
                                    // Parent ship
                                    Inventory_Ship = item.Inventory_Ship,
                                    GameData_Ship = item.GameData_Ship,
                                    // Child item
                                    Inventory_Item = shipItem,
                                    GameData_Item = gameItem,
                                });

                foreach (var childItem in children.SelectMany(c => this._GetAttachedItems(c)))
                    yield return childItem;
            }
        }

        #endregion

        #region Inventory

        /// <summary>
        /// The ship that is currently selected
        /// </summary>
        public Inventory.Ship Inventory_Ship
        {
            get { return this.Inventory_ShipMap.GetValue(this.ShipID, null); }
        }

        private Dictionary<Guid, Inventory.Item> _inventory_ItemMap;
        public Dictionary<Guid, Inventory.Item> Inventory_ItemMap
        {
            get { return this._inventory_ItemMap = this._inventory_ItemMap ?? this.Player.Items.ToDictionary(k => k.ID, v => v); }
            set { this._inventory_ItemMap = value; }
        }

        private Dictionary<Guid, Inventory.Ship> _inventory_ShipMap;
        public Dictionary<Guid, Inventory.Ship> Inventory_ShipMap
        {
            get { return this._inventory_ShipMap = this._inventory_ShipMap ?? this.Player.Ships.ToDictionary(k => k.ID, v => v); }
            set { this._inventory_ShipMap = value; }
        }

        #endregion

        #region Game Data

        /// <summary>
        /// The ship that is currently selected
        /// </summary>
        public Ships.Vehicle GameData_Ship
        {
            get { return this.GameData_ShipMap.GetValue(this.ShipID, null); }
        }

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
                     orderby part.DisplayName.ToLocalized()
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
                         orderby part.DisplayName.ToLocalized()
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
                        this._gameData_CategoryMap[missingKey] = new Dictionary<Guid, Items.Item> { };
                }

                return this._gameData_CategoryMap;
            }
        }

        public Dictionary<Guid, Xml.ItemPort> _gameData_PortMap;
        public Dictionary<Guid, Xml.ItemPort> GameData_PortMap
        {
            get
            {
                return this._gameData_PortMap = this._gameData_PortMap ??
                    (from item in this.Inventory_ItemMap.Values
                     let parts = this.GameData_PartsMap.GetValue(item.ID, null)
                     where parts != null
                     from part in parts
                     from port in part.ItemPorts
                     orderby port.DisplayName.ToLocalized()
                     orderby port.Name.ToLocalized()
                     orderby part.Name.ToLocalized()
                     select new
                     {
                         Key = item.ID,
                         Value = port
                     }).ToDictionary(k => k.Key, v => v.Value);
            }
        }

        private Dictionary<Guid, List<Ships.Part>> _gameData_PartsMap;
        public Dictionary<Guid, List<Ships.Part>> GameData_PartsMap
        {
            get
            {
                return this._gameData_PartsMap = this._gameData_PartsMap ??
                    (from kvp in this.GameData_ShipMap
                     let id = kvp.Key
                     let ship = kvp.Value
                     from part in ship.Parts.SelectMany(p => this.GetParts(p))
                     group part by id into groupedParts
                     select groupedParts).ToDictionary(k => k.Key, v => v.ToList());
            }
        }
        private IEnumerable<Ships.Part> GetParts(Ships.Part parent)
        {
            if (!parent.SkipPart)
            {
                if (parent.Parts != null)
                    foreach (var part in parent.Parts.SelectMany(p => this.GetParts(p)))
                        yield return part;


                yield return parent;
            }
        }

        #endregion

        #region Not Used

        //private Dictionary<Guid, Dictionary<Guid, Inventory.Item>> _inventory_ManufacturerMap;
        //public Dictionary<Guid, Dictionary<Guid, Inventory.Item>> zzInventory_ManufacturerMap
        //{
        //    get
        //    {
        //        return this._inventory_ManufacturerMap = this._inventory_ManufacturerMap ??
        //            (from item in this.Player.Items
        //             group item by item.ManufacturerID into groupedItems
        //             select new
        //             {
        //                 Key = groupedItems.Key,
        //                 Value = groupedItems.ToDictionary(k => k.ID, v => v)
        //             }).ToDictionary(k => k.Key, v => v.Value);
        //    }
        //    set { this._inventory_ManufacturerMap = value; }
        //}

        #endregion
    }
}
