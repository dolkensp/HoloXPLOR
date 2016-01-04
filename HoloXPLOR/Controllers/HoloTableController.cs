using HoloXPLOR.Data;
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

        public ActionResult Detail(String id)
        {
            String filename = Server.MapPath(String.Format(@"~/App_Data/{0}.xml", id));
            
            if (System.IO.File.Exists(filename))
            {
                String inXML = System.IO.File.ReadAllText(filename);

                Player model = inXML.FromXML<Player>();

                return View(model);
            }

            throw new FileNotFoundException("Unable to load specified xml", String.Format("{0}.xml", id));
        }
    }
}