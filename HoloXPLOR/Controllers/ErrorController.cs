using Dolkens.Framework.Caching;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HoloXPLOR.Controllers
{
    public class ErrorController : Controller
    {
        [ValidateInput(false)]
        public ActionResult JsError(String message, String stack, String name, String args, String url)
        {
            var data = args.FromJSON();

            // By cachine this method, we prevent more than 1 of the same error being logged in any 15 minute window
            CacheUtils.GetCachedData(CacheUtils.DefaultSettings, () =>
            {
                return Elmah.ErrorLog.GetDefault(System.Web.HttpContext.Current).Log(
                    new Elmah.Error(
                        new JavascriptException(message)
                        {
                            Args = args.FromJSON(),
                            Name = name,
                            Stack = stack,
                            Url = url,
                        }
                    )
                );
            }, message, stack, name, url);

            return new EmptyResult { };
        }
    }
}