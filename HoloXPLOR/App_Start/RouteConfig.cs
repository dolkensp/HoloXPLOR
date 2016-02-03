using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HoloXPLOR
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "NotFound",
                url: "NotFound",
                defaults: new { controller = "HoloTable", action = "NotFound", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "JsError",
                url: "JsError",
                defaults: new { controller = "Error", action = "JsError", id = UrlParameter.Optional }
            );

            routes.MapRoute(

                name: "HangarUpload",
                url: "HoloTable/Upload",
                defaults: new { controller = "HoloTable", action = "Upload" }
            );

            routes.MapRoute(
                name: "Hangar",
                url: "HoloTable/{id}",
                defaults: new { controller = "HoloTable", action = "Hangar" }
            );

            routes.MapRoute(
                name: "HangarDownload",
                url: "HoloTable/{id}/Download",
                defaults: new { controller = "HoloTable", action = "Download" }
            );

            routes.MapRoute(
                name: "Ship",
                url: "HoloTable/{id}/{shipid}/{action}",
                defaults: new { controller = "HoloTable", action = "Ship" }
            );

            routes.MapRoute(
                name: "Media",
                url: "media/{slug}/{format}/{filename}",
                defaults: new { controller = "Media", action = "Cache" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
