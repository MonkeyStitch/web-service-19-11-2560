using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoMVCWeb.Startup))]
namespace DemoMVCWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
