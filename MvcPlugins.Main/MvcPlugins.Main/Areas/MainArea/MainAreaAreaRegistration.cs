using System.Web.Mvc;

namespace MvcPlugins.Main.Areas.MainArea
{
    public class MainAreaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MainArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {

            context.MapRoute(
                name: "MainArea_default",
                url: "MainArea/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional, controller = "Home" },
                namespaces: new[] { "MvcPlugins.Main.Areas.MainArea.Controllers" }
            );
        }
    }
}