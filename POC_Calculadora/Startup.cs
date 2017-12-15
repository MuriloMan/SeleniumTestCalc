using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(POC_Calculadora.Startup))]
namespace POC_Calculadora
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
