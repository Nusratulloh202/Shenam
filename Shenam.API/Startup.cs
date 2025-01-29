//====================================================
//Copyright(c) Coalition of Good-Hearted Engineers
//Free To Use Comfort and Peace
//====================================================

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Client.Extensions.Msal;
using Microsoft.OpenApi.Models;
using Shenam.API.Brokers.Storages;
namespace Shenam.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)=>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var apiInfo = new OpenApiInfo
            {
                Title = "Shenam.API",
                Version = "v1"
            };

            services.AddDbContext<StorageBroker>();
            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    name:"v1",
                    info:apiInfo);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                string url = "/swagger/v1/swagger.json";
                string name = "Shenam.API v1";

                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                app.UseSwaggerUI(options => 
                options.SwaggerEndpoint(url, name));
            }
                
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
                endpoints.MapControllers());
         
        }
    }
}
