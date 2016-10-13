using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebQueryGenerator.Startup))]
namespace WebQueryGenerator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
