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
        public ActionResult Ship(String id, Guid shipID, Guid partId, Guid? parentId, String portName)
        {
            var model = new DetailModel(id, shipID);

            var ship = model.Player.Ships.Where(s => s.ID == shipID).FirstOrDefault();
            
            var newPart = model.Player.Items.Where(i => i.ID == partId).FirstOrDefault();

            var oldPart = model.Player.Hangar.Inventory.Items.Where(i => i.ID == partId).FirstOrDefault() ??
                model.Player.Ships.SelectMany(s => s.Inventory.Items).Where(i => i.ID == partId).FirstOrDefault();
            
            var port = model.Player.Items.Where(i => i.ID == parentId).SelectMany(i => i.Ports.Items).Where(p => p.PortName == portName).FirstOrDefault() ??
                ship.Ports.Items.Where(p => p.PortName == portName).FirstOrDefault();

            port.ItemID = partId;
            oldPart.ID = newPart.ID;

            model.Save();

            return View(model);
        }
    }
}