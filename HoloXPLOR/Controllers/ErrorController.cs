using Dolkens.Framework.Caching;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HoloXPLOR.Controllers
{
    public class ErrorController : Controller
    {
        [ValidateInput(false)]
        public ActionResult JsError(String message, String stack, String name, String args, String url)
        {
            dynamic data = null;

            if (!String.IsNullOrEmpty(args))
            {
                data = args.FromJSON();
            }

            // By cachine this method, we prevent more than 1 of the same error being logged in any 15 minute window
            CacheUtils.GetCachedData(CacheUtils.DefaultSettings, () =>
            {
                return Elmah.ErrorLog.GetDefault(System.Web.HttpContext.Current).Log(
                    new Elmah.Error(
                        new JavascriptException(message)
                        {
                            Args = data,
                            Name = name,
                            Stack = stack,
                            Url = url,
                        }
                    )
                );
            }, message, stack, name, url);

            return new EmptyResult { };
        }

        public ActionResult NotFound(String url)
        {
            if (!String.Equals(url, "NotFound", StringComparison.InvariantCultureIgnoreCase))
            {
                return RedirectToAction("NotFound", new { url = "NotFound" });
            }

            this.Response.StatusCode = (Int32)HttpStatusCode.Gone;
            this.Response.TrySkipIisCustomErrors = true;

            HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Response.Cache.SetExpires(DateTime.UtcNow);
            HttpContext.Response.Cache.SetMaxAge(TimeSpan.FromMilliseconds(0));

            return View();
        }

        public ActionResult NotAllowed()
        {
            this.Response.StatusCode = (Int32)HttpStatusCode.Forbidden;
            this.Response.TrySkipIisCustomErrors = true;

            return View();
        }
    }
}