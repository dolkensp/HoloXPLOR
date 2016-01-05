using HoloXPLOR.Data;
using HoloXPLOR.Data.XML.Inventory;
using HoloXPLOR.Models.HoloTable;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}