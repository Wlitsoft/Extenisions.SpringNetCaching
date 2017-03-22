using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Wlitsoft.Framework.Caching.Redis;
using Wlitsoft.Framework.Common;

namespace DistributedCache.MVC4WebAppQuickStart
{
    public class Global : Spring.Web.Mvc.SpringMvcApplication
    {
        private static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("default", "{controller}/{action}",
                new { controller = "Home", action = "Index" });
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);

            App.Builder.SetRedisCacheConfigByAppSettings();
        }
    }
}