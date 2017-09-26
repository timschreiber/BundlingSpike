using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BundlingSpike.Web.Startup))]
namespace BundlingSpike.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
