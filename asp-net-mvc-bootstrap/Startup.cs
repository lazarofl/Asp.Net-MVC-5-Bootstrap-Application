using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(asp_net_mvc_bootstrap.Startup))]
namespace asp_net_mvc_bootstrap
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
