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
                name: "Thanks",
                url: "Thanks",
                defaults: new { controller = "Home", action = "Thanks" }
            );

            routes.MapRoute(
                name: "JsError",
                url: "JsError",
                defaults: new { controller = "Error", action = "JsError" }
            );

            routes.MapRoute(
                name: "HangarUpload",
                url: "HoloTable/Upload",
                defaults: new { controller = "HoloTable", action = "Upload" }
            );

            routes.MapRoute(
                name: "NotAllowed",
                url: "NotAllowed",
                defaults: new { controller = "Error", action = "NotAllowed" }
            );

            routes.MapRoute(
                name: "Hangar",
                url: "HoloTable/{id}",
                defaults: new { controller = "HoloTable", action = "Hangar" }
            );

            routes.MapRoute(
                name: "HangarInventory",
                url: "HoloTable/{id}/Inventory",
                defaults: new { controller = "HoloTable", action = "Inventory" }
            );

            routes.MapRoute(
                name: "HangarDelete",
                url: "HoloTable/{id}/Delete",
                defaults: new { controller = "HoloTable", action = "Delete" }
            );

            routes.MapRoute(
                name: "HangarDownload",
                url: "HoloTable/{id}/Download",
                defaults: new { controller = "HoloTable", action = "Download" }
            );

            routes.MapRoute(
                name: "Ship",
                url: "HoloTable/{id}/{shipid}",
                defaults: new { controller = "HoloTable", action = "Ship" }
            );

            routes.MapRoute(
                name: "HangarRating",
                url: "Rating/{id}/{shipid}",
                defaults: new { controller = "HoloTable", action = "Rating", id = "ANVL_Hornet_F7CM", shipid = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Media",
                url: "media/{slug}/{format}/{filename}",
                defaults: new { controller = "Media", action = "Cache" }
            );

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "NotFound",
                url: "{url}",
                defaults: new { controller = "Error", action = "NotFound" }
            );
        }
    }
}
