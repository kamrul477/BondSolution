using Microsoft.Owin;
using Owin;
using Microsoft.Framework.DependencyInjection;
using templateMvc.Services;

[assembly: OwinStartupAttribute(typeof(templateMvc.Startup))]
namespace templateMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IInventoryService, InventoryService>();
        }
    }
}
