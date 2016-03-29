using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace HoloXPLOR.Controllers
{
    public abstract class _BaseController : Controller
    {
        private HashSet<String> _secureHosts = new HashSet<String>(StringComparer.InvariantCultureIgnoreCase) {
            "holoxplor.space",
            "ptu.holoxplor.space",
        };

        private List<Regex> _pageRules = new List<Regex>
        {
            new Regex("^/?$", RegexOptions.IgnoreCase),
            new Regex("^/HoloTable/Sample/?$", RegexOptions.IgnoreCase),
            new Regex("^/Thanks/?$", RegexOptions.IgnoreCase),
            new Regex("^/Media/", RegexOptions.IgnoreCase),
            new Regex("^/Rating/[a-z0-9_]+/?$", RegexOptions.IgnoreCase),
        };

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            #region Force HTTPS

            var hostname = filterContext.HttpContext.Request.Url.Host;
            var path = filterContext.HttpContext.Request.Url.PathAndQuery;
            var scheme = filterContext.HttpContext.Request.Url.Scheme;
            var xfHeader = filterContext.HttpContext.Request.Headers["x-forwarded-proto"];

            // Redirect HTTP requests to HTTPS
            if (this._secureHosts.Contains(hostname) &&
                !String.Equals(xfHeader, Uri.UriSchemeHttps, StringComparison.InvariantCultureIgnoreCase) &&
                !String.Equals(scheme, Uri.UriSchemeHttps, StringComparison.InvariantCultureIgnoreCase))
                filterContext.Result = this.RedirectPermanent(String.Format("{0}://{1}{2}", Uri.UriSchemeHttps, hostname, path));

            #endregion

            #region Force live URLs

            if (String.Equals(hostname, "www.holoxplor.space", StringComparison.InvariantCultureIgnoreCase))
                filterContext.Result = this.RedirectPermanent(String.Format("{0}://{1}{2}", Uri.UriSchemeHttps, "holoxplor.space", path));

            if (String.Equals(hostname, "holoxplor.azurewebsites.net", StringComparison.InvariantCultureIgnoreCase))
                filterContext.Result = this.RedirectPermanent(String.Format("{0}://{1}{2}", Uri.UriSchemeHttps, "holoxplor.space", path));

            if (String.Equals(hostname, "holoxplor-ptu.azurewebsites.net", StringComparison.InvariantCultureIgnoreCase))
                filterContext.Result = this.RedirectPermanent(String.Format("{0}://{1}{2}", Uri.UriSchemeHttps, "ptu.holoxplor.space", path));

            if (HoloXPLOR_App.IsPTU && !HoloXPLOR_App.HasPTU)
                filterContext.Result = this.RedirectTemporary(filterContext, String.Format("{0}://{1}{2}", Uri.UriSchemeHttps, "holoxplor.space", path));

            #endregion
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.RouteData.Values.Add("IsPTU", HoloXPLOR_App.IsPTU);
            filterContext.RouteData.Values.Add("IsLive", !HoloXPLOR_App.IsPTU);
            filterContext.RouteData.Values.Add("HasPTU", HoloXPLOR_App.HasPTU);

            this.SetCaching(filterContext);

            base.OnActionExecuting(filterContext);
        }

        private void SetCaching(ActionExecutingContext filterContext)
        {
            foreach (var rule in this._pageRules)
            {
                if (rule.IsMatch(filterContext.HttpContext.Request.Url.PathAndQuery))
                {
                    filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.Public);
                    filterContext.HttpContext.Response.Cache.SetExpires(DateTime.Today.AddDays(7));
                    filterContext.HttpContext.Response.Cache.SetMaxAge(TimeSpan.FromHours(168));
                    filterContext.HttpContext.Response.DisableKernelCache();

                    return;
                }
            }

            filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            filterContext.HttpContext.Response.Cache.SetExpires(DateTime.Now);
            filterContext.HttpContext.Response.Cache.SetMaxAge(TimeSpan.FromMilliseconds(0));
        }

        private RedirectResult RedirectTemporary(AuthorizationContext filterContext, String url)
        {
            filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            filterContext.HttpContext.Response.Cache.SetExpires(DateTime.Now);
            filterContext.HttpContext.Response.Cache.SetMaxAge(TimeSpan.FromMilliseconds(0));

            return this.Redirect(url);
        }
    }
}