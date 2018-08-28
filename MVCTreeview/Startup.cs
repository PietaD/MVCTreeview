using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using MVCTreeview.Models;
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
