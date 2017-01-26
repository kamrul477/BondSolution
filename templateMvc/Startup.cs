using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(templateMvc.Startup))]
namespace templateMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
