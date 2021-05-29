using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RegistroEventosUSAM.Startup))]
namespace RegistroEventosUSAM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
