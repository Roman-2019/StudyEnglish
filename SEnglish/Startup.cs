using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SEnglish.Startup))]
namespace SEnglish
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
