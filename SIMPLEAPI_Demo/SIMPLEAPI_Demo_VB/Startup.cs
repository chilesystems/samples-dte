using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SIMPLEAPI_Demo_VB.StartupOwin))]

namespace SIMPLEAPI_Demo_VB
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
