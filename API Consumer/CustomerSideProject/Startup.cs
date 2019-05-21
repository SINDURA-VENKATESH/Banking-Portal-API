using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomerSideProject.Startup))]
namespace CustomerSideProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
