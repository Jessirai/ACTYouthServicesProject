using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ACTYouthServicesWeb.Startup))]
namespace ACTYouthServicesWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
