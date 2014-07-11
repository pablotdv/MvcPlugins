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
            get { return "Plugin1"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Plugin1",
                "Plugin1/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional, controller = "Home" },
                namespaces: new[] { "MvcPlugins.Plugin1.Controllers" });
        }
    }
}