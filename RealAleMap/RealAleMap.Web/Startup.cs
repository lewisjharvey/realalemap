using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RealAleMap.Web.Startup))]
namespace RealAleMap.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
