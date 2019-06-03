using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AgriInvestment.WebUI.Startup))]
namespace AgriInvestment.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
