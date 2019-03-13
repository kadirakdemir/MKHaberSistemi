using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MKHaberSistemi.Web.Startup))]
namespace MKHaberSistemi.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
