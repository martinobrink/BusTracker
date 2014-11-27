using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;

namespace BusTracker
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services
                .AddSignalR()
                .Configure(options => { options.Hubs.EnableDetailedErrors = true; });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();

            app.UseSignalR();

            app.UseWelcomePage();
        }
    }
}
