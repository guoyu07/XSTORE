using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LocalWeb.Startup))]
namespace LocalWeb
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
