using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCTreeview.Startup))]
namespace MVCTreeview
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
