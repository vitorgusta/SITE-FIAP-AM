using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Site_MVC_FinTech.Startup))]
namespace Site_MVC_FinTech
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
