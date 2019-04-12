using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_8_4_WebShop.Startup))]
namespace _8_4_WebShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
