using HoloXPLOR.Data;
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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // return View();

            String inXML = System.IO.File.ReadAllText(Server.MapPath(@"~/App_Data/db_dolkensp_2.0.xml"));

            Player inTest = inXML.FromXML<Player>();

            Type t = typeof(Player);

            XmlSerializer xs = new XmlSerializer(typeof(Player));
            XmlTextWriter xw = new XmlTextWriter(Server.MapPath(@"~/App_Data/db_dolkensp_2.0_new.xml"), Encoding.UTF8);

            // xw.Settings = new XmlWriterSettings
            // {
            //     Indent = true,
            //     IndentChars = " ",
            //     OmitXmlDeclaration = true,
            //     ConformanceLevel = ConformanceLevel.Fragment
            // };
            xw.Indentation = 1;
            xw.IndentChar = ' ';
            xw.Formatting = Formatting.Indented;

            xw.WriteWhitespace("");
            xs.Serialize(xw, inTest);
            xw.Close();

            String outXML = inTest.ToXML(); // .Remove(0, 39).Trim();

            return new ContentResult
            {
                Content = outXML,
                ContentEncoding = Encoding.UTF8,
                ContentType = "text/xml"
            };
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}