using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NCLS.WEB.Startup))]
namespace NCLS.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
