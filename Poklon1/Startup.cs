using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Poklon1.Startup))]
namespace Poklon1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
