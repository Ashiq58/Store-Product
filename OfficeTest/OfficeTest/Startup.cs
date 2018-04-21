using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OfficeTest.Startup))]
namespace OfficeTest
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
