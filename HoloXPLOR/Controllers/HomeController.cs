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
            using (var fs = System.IO.File.OpenRead(Server.MapPath(@"~/App_Data/Game.dcb")))
            {
                using (var br = new BinaryReader(fs))
                {
                    var df = new DataForge.DataForge(br);

                    foreach (var record in df.RecordDefinitionTable)
                    {
                        var structDefinition = df.StructDefinitionTable[record.StructIndex];
                        if (structDefinition.Name == "AmmoParams")
                        {
                            var xml = df.DataMap[record.StructIndex][record.VariantIndex].Rename(structDefinition.Name).OuterXml;
                            // var test = xml.FromXML<HoloXPLOR.Data.DataForge.AmmoParams>();
                        }
                    }
                }
            }

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

            return View();
        }

        public ActionResult Thanks()
        {
            return View();
        }
    }
}