using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPlugins.Main.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AtualizarPlugins()
        {
            try
            {
                HttpRuntime.UnloadAppDomain();


                System.IO.File.SetLastWriteTimeUtc(Server.MapPath("~/global.asax"), DateTime.UtcNow);
                System.IO.File.SetLastWriteTimeUtc(Server.MapPath("~/web.config"), DateTime.UtcNow);
                System.IO.File.SetLastWriteTimeUtc(Server.MapPath("~/bin/MvcPlugins.Main.dll"), DateTime.UtcNow);
            }
            catch
            {
                throw new Exception("Falha ao atualizar");
            }

            AppDomain.CreateDomain("");

            return View("Index");
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}