using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WyseOwl.Startup))]
namespace WyseOwl
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
