using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPlugins.Main
{
    public class PluginEngine : RazorViewEngine
    {
        public PluginEngine()
            : base()
        {
            AreaMasterLocationFormats = new[] 
            {
                "~/Areas/{2}/Views/{1}/{0}.master",
                "~/Areas/{2}/Views/Shared/{0}.master",
                "~/Plugins/{2}/Views/Shared/{0}.master",
            };

        }
    }
}