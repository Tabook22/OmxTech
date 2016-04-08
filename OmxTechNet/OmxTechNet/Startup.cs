using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OmxTechNet.Startup))]
namespace OmxTechNet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
