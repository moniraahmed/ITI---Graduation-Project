using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITIAuthorizationServer.Startup))]
namespace ITIAuthorizationServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
