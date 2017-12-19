using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCTest.WebApp.Startup))]
namespace MVCTest.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
