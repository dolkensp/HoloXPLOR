﻿using System;
using System.Collections.Generic;
using System.Linq;
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

            #region Force new URLs

            if (String.Equals(hostname, "www.holoxplor.space", StringComparison.InvariantCultureIgnoreCase))
                filterContext.Result = this.RedirectPermanent(String.Format("{0}://{1}{2}", Uri.UriSchemeHttps, "holoxplor.space", path));

            if (String.Equals(hostname, "holoxplor.azurewebsites.net", StringComparison.InvariantCultureIgnoreCase))
                filterContext.Result = this.RedirectPermanent(String.Format("{0}://{1}{2}", Uri.UriSchemeHttps, "holoxplor.space", path));

            if (String.Equals(hostname, "holoxplor-ptu.azurewebsites.net", StringComparison.InvariantCultureIgnoreCase))
                filterContext.Result = this.RedirectPermanent(String.Format("{0}://{1}{2}", Uri.UriSchemeHttps, "ptu.holoxplor.space", path));

            #endregion
        }
    }
}