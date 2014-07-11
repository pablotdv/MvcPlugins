using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPlugins.Plugin1
{
    public class Plugin1AreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Plugin2"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Plugin2",
                "Plugin2/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional, controller = "Home" },
                namespaces: new[] { "MvcPlugins.Plugin2.Controllers" });
        }
    }
}