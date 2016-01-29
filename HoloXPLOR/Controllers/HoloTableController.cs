using HoloXPLOR.Data;
using HoloXPLOR.Data.XML.Inventory;
using HoloXPLOR.Models.HoloTable;
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

namespace HoloXPLOR.Controllers
{
    public class HoloTableController : Controller
    {
        // GET: HoloTable
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Hangar(String id)
        {
            var model = new DetailModel(id);

            return View(model);
        }

        public ActionResult Ship(String id, Guid shipID)
        {
            var model = new DetailModel(id, shipID);

            return View(model);
        }

        [HttpPost]
        public ActionResult Ship(String id, Guid shipID, Guid newPartID, Guid? parentID, String portName)
        {
            var model = new DetailModel(id, shipID);

            var ship = model.Player.Ships.Where(s => s.ID == shipID).SingleOrDefault();

            var newItem = model.Player.Items.Where(i => i.ID == newPartID).SingleOrDefault();

            var port = model.Player.Items.Where(i => i.ID == parentID).SelectMany(i => i.Ports.Items).Where(p => p.PortName == portName).SingleOrDefault() ??
                ship.Ports.Items.Where(p => p.PortName == portName).SingleOrDefault();

            var oldPartID = port.ItemID;

            #region Move Old Child Items To Hangar

            var hosts = model.Player.Items.Where(i => i.ID == oldPartID).ToList();

            var nextHost = hosts.FirstOrDefault();

            List<Inventory.InventoryItem> removed = new List<Inventory.InventoryItem> { };

            removed.AddRange(ship.Inventory.Items.Where(i => i.ID == oldPartID));
            removed.AddRange(model.Player.Ships.SelectMany(s => s.Inventory.Items).Where(i => i.ID == oldPartID));
            model.Player.Hangar.Inventory.Items = model.Player.Hangar.Inventory.Items.Where(i => i.ID != oldPartID).ToArray();
            ship.Inventory.Items = ship.Inventory.Items.Where(i => i.ID != oldPartID).ToArray();

            while (nextHost != null)
            {
                hosts.RemoveAt(0);

                if (nextHost.Ports.Items != null)
                {

                    foreach (var childPort in nextHost.Ports.Items)
                    {
                        hosts.AddRange(model.Player.Items.Where(i => i.ID == childPort.ItemID));
                        removed.AddRange(ship.Inventory.Items.Where(i => i.ID == childPort.ItemID));
                        removed.AddRange(model.Player.Ships.SelectMany(s => s.Inventory.Items).Where(i => i.ID == childPort.ItemID));
                        model.Player.Hangar.Inventory.Items = model.Player.Hangar.Inventory.Items.Where(i => i.ID != childPort.ItemID).ToArray();
                        ship.Inventory.Items = ship.Inventory.Items.Where(i => i.ID != childPort.ItemID).ToArray();
                    }

                    model.Player.Hangar.Inventory.Items = model.Player.Hangar.Inventory.Items.Concat(removed).ToArray();
                }


                nextHost = hosts.FirstOrDefault();
            }

            #endregion

            #region Move New Child Items To Ship

            hosts = model.Player.Items.Where(i => i.ID == newPartID).ToList();

            nextHost = hosts.FirstOrDefault();

            removed = new List<Inventory.InventoryItem> { };

            removed.AddRange(ship.Inventory.Items.Where(i => i.ID == newPartID));
            removed.AddRange(model.Player.Ships.SelectMany(s => s.Inventory.Items).Where(i => i.ID == newPartID));
            model.Player.Hangar.Inventory.Items = model.Player.Hangar.Inventory.Items.Where(i => i.ID != newPartID).ToArray();
            ship.Inventory.Items = ship.Inventory.Items.Where(i => i.ID != newPartID).ToArray();

            while (nextHost != null)
            {
                hosts.RemoveAt(0);

                if (nextHost.Ports.Items != null)
                {
                    foreach (var childPort in nextHost.Ports.Items)
                    {
                        hosts.AddRange(model.Player.Items.Where(i => i.ID == childPort.ItemID));
                        removed.AddRange(ship.Inventory.Items.Where(i => i.ID == childPort.ItemID));
                        removed.AddRange(model.Player.Ships.SelectMany(s => s.Inventory.Items).Where(i => i.ID == childPort.ItemID));
                        model.Player.Hangar.Inventory.Items = model.Player.Hangar.Inventory.Items.Where(i => i.ID != childPort.ItemID).ToArray();
                        ship.Inventory.Items = ship.Inventory.Items.Where(i => i.ID != childPort.ItemID).ToArray();
                    }

                    ship.Inventory.Items = ship.Inventory.Items.Concat(removed).ToArray();
                }


                nextHost = hosts.FirstOrDefault();
            }

            #endregion

            port.ItemID = newPartID;

            model.Player.VehicleID = shipID;
            
            model.Save();

            return View(model);
        }
    }
}