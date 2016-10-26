using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemadeGestionEscolar.Startup))]
namespace SistemadeGestionEscolar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
