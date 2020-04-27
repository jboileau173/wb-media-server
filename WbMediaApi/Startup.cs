using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WbMediaCore.Configurations;
using WbMediaCore.Features;
using WbMediaCore.Features.CreateFileFeature;
using WbMediaCore.Messages;
using WbMediaCore.Repositories;
using WbMediaCore.Services;
using WbMediaRepository.Contexts;
using WbMediaRepository.Repositories;
using WbMediaServices;

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

            _registerConfigurations(services);
            _registerContexts(services);
            _registerRepositories(services);
            _registerServices(services);
            _registerFeatures(services);
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

        private void _registerConfigurations(IServiceCollection services)
        {
            services.AddScoped<ILocationOptions, LocationOptions>(x =>
            {
                var locationOptions = new LocationOptions();
                Configuration.Bind("Location", locationOptions);

                return locationOptions;
            });

            services.AddScoped<IDatabaseOptions, DatabaseOptions>(x =>
            {
                var databaseOptions = new DatabaseOptions();
                Configuration.Bind("Database", databaseOptions);

                return databaseOptions;
            });
        }

        private void _registerContexts(IServiceCollection services)
        {
            services.AddDbContext<Context>(ServiceLifetime.Scoped);
        }

        private void _registerRepositories(IServiceCollection services)
        {
            services.AddScoped<IFileRepository, FileRepository>();
        }

        private void _registerServices(IServiceCollection services)
        {
            services.AddScoped<IFileService, FileService>();
        }

        private void _registerFeatures(IServiceCollection services)
        {
            services.AddScoped<IFeature<CreateFileRequest, CreateFileResponse>, CreateFileFeature>();
        }
    }
}
