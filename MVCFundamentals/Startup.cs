using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCFundamentals.Startup))]
namespace MVCFundamentals
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
