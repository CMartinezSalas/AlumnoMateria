using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExamenDigiPro.Startup))]
namespace ExamenDigiPro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
