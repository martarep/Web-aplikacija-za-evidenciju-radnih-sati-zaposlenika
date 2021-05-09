using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AZERS.Startup))]
namespace AZERS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
