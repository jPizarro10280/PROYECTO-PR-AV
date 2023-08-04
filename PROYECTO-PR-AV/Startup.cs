using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PROYECTO_PR_AV.Startup))]
namespace PROYECTO_PR_AV
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
