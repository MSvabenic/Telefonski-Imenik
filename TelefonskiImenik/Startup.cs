using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TelefonskiImenik.Startup))]
namespace TelefonskiImenik
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
