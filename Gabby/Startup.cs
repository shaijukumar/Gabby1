using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gabby.Startup))]
namespace Gabby
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
