using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPlugins.Plugin1.Controllers
{
    public class HomePlugin1Controller : Controller
    {
        // GET: HomePlugin1
        public ActionResult Index()
        {
            return View();
        }
    }
}