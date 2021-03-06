using ecommerce.WebApi.Config.API;
using ecommerce.WebApi.Config.AutoMapper;
using ecommerce.WebApi.Config.DI;
using ecommerce.WebApi.Config.JWT;
using ecommerce.WebApi.Config.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ecommerce.WebApi
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
            services.AddJWTConfig(Configuration);

            services.AddAutoMapper(typeof(AutoMapperConfigProfile));

            services.AddAPIConfig();

            services.AddSwaggerConfig();

            services.ResolveDependencies(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            IApiVersionDescriptionProvider provider)
        {
            app.UseApiConfig(env);

            app.UseSwaggerConfig(provider);
        }
    }
}
