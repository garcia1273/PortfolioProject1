using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AJWebsite.Startup))]
namespace AJWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
