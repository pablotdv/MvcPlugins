using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcPlugins.Main.Startup))]
namespace MvcPlugins.Main
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
