using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(computer_reparatieshop.Startup))]
namespace computer_reparatieshop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
