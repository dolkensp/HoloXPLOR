using HoloXPLOR.Data;
using HoloXPLOR.Data.XML.Spaceships;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;

namespace HoloXPLOR.Controllers
{
    public class HomeController : _BaseController
    {
        private Object _resetLock = new Object();

        public ActionResult Index()
        {
            try
            {
                FileInfo sample = new FileInfo(Server.MapPath("~/App_Data/sample.xml"));
                FileInfo original = new FileInfo(Server.MapPath("~/App_Data/sample.tpl"));

                if (!sample.Exists || (sample.LastWriteTime - original.LastWriteTime).TotalHours > 24)
                {
                    lock (_resetLock)
                    {
                        if ((sample.LastWriteTime - original.LastWriteTime).TotalHours > 24)
                        {
                            sample.Delete();
                            original.CopyTo(Server.MapPath("~/App_Data/sample.xml"));
                            System.IO.File.SetLastWriteTime(Server.MapPath("~/App_Data/sample.tpl"), DateTime.Now);
                        }
                    }
                }
            }
            catch (Exception) { }

            this.Response.Cache.SetCacheability(HttpCacheability.Public);
            this.Response.Cache.SetExpires(DateTime.Today.AddDays(7));
            this.Response.Cache.SetMaxAge(TimeSpan.FromHours(168));

            return View();
        }

        public ActionResult Thanks()
        {

            this.Response.Cache.SetCacheability(HttpCacheability.Public);
            this.Response.Cache.SetExpires(DateTime.Today.AddDays(7));
            this.Response.Cache.SetMaxAge(TimeSpan.FromHours(168));

            return View();
        }
    }
}