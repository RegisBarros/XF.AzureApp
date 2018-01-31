using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(fiap_azure_appService.Startup))]

namespace fiap_azure_appService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}