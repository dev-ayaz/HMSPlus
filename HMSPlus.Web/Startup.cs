using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HMSPlus.Web.Startup))]
namespace HMSPlus.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
