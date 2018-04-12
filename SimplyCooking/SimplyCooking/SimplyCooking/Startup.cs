using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimplyCooking.Startup))]
namespace SimplyCooking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
