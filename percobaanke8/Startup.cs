using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(percobaanke8.Startup))]
namespace percobaanke8
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
