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
        public ActionResult Ship(String id, Guid shipID, Guid partId, Guid? parentId)
        {
            var model = new DetailModel(id, shipID);

            Inventory.Item part = model.Inventory_ItemMap.GetValue(partId, null);
            Inventory.Item parent = null;

            if (parentId.HasValue)
                parent = model.Inventory_ItemMap.GetValue(parentId.Value, null);

            return View(model);
        }
    }
}