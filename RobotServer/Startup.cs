using RobotServer.Entities;

using RobotServer.Services;
using Microsoft.EntityFrameworkCore;

namespace RobotServer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc(o => o.EnableDetailedErrors = true);
         
            services.AddDbContext<RobotContext>(opt =>
               opt.UseInMemoryDatabase("RobotList"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseGrpcWeb();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<RobotsService>().EnableGrpcWeb();
            });
        }

    }
}
