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

            if (_BaseController.IsPTU && !_BaseController.HasPTU)
                filterContext.Result = this.RedirectPermanent(String.Format("{0}://{1}{2}", Uri.UriSchemeHttps, "holoxplor.space", path));

            #endregion
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.RouteData.Values.Add("IsPTU", _BaseController.IsPTU);
            filterContext.RouteData.Values.Add("IsLive", !_BaseController.IsPTU);
            filterContext.RouteData.Values.Add("HasPTU", _BaseController.HasPTU);

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

        private static Object _ptuLock = new Object { };
        private static Boolean? _hasPTU;
        public static Boolean HasPTU
        {
            get
            {
                var launcherFile = System.Web.HttpContext.Current.Server.MapPath(@"~/App_Data/_LauncherInfo");

                if (!_BaseController._hasPTU.HasValue || !System.IO.File.Exists(launcherFile) || (DateTime.Now - System.IO.File.GetLastWriteTime(launcherFile)).TotalDays > 1)
                {
                    lock (_ptuLock)
                    {
                        if (!_BaseController._hasPTU.HasValue || !System.IO.File.Exists(launcherFile) || (DateTime.Now - System.IO.File.GetLastWriteTime(launcherFile)).TotalDays > 1)
                        {
                            try
                            {
                                using (WebClient client = new WebClient())
                                {
                                    if (System.IO.File.Exists(launcherFile))
                                    {
                                        System.IO.File.Delete(launcherFile);
                                    }
                                    client.DownloadFile("http://manifest.robertsspaceindustries.com/Launcher/_LauncherInfo", launcherFile);
                                }

                                var lines = System.IO.File.ReadAllLines(launcherFile);
                                var publicVersion = "";
                                var testVersion = "";

                                foreach (var line in lines)
                                {
                                    var parts = line.Split(new String[] { " = " }, StringSplitOptions.RemoveEmptyEntries);
                                    if (parts.Length > 0)
                                    {
                                        if (parts[0] == "Public_version")
                                        {
                                            publicVersion = parts[1];
                                        }
                                        else if (parts[0] == "Test_version")
                                        {
                                            testVersion = parts[1].Replace(" - PTU", "");
                                        }
                                    }
                                }

                                _BaseController._hasPTU = String.Compare(testVersion, publicVersion) > 0;
                            }
                            catch (Exception e)
                            {
                                Elmah.ErrorLog.GetDefault(System.Web.HttpContext.Current).Log(new Elmah.Error(e));
                                _BaseController._hasPTU = false;
                            }
                        }
                    }
                }

                return _BaseController._hasPTU ?? false;
            }
        }

        public static Boolean IsPTU
        {
            get { return String.Equals(System.Web.HttpContext.Current.Request.Url.Host, "ptu.holoxplor.space", StringComparison.InvariantCultureIgnoreCase); }
        }
    }
}