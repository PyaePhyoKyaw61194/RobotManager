using RobotServer.Repo;
using RobotServer.Services;

namespace RobotServer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc(o => o.EnableDetailedErrors = true);
            services.AddSingleton<IRobotRepo, RobotRepo>();
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
