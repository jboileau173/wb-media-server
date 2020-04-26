using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WbMediaConfig;
using WbMediaCore.Features;
using WbMediaCore.Features.CreateMediaFeature;
using WbMediaCore.Messages;
using WbMediaCore.Services;

namespace WbMediaApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<ILocationOptions, LocationOptions>(x =>
            {
                var locationOptions = new LocationOptions();
                Configuration.Bind("Location", locationOptions);

                return locationOptions;
            });

            // Services
            services.AddScoped<IMediaService, MediaService>();

            // Features
            services.AddScoped<IFeature<CreateMediaRequest, CreateMediaResponse>, CreateMediaFeature>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
