using ecommerce.Encomenda.Application.Interfaces;
using ecommerce.Encomenda.Application.Services;
using ecommerce.Encomenda.Data.Repository;
using ecommerce.Encomenda.Domain.Interfaces;
using ecommerce.WebApi.Config.Swagger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Data;
using System.Data.SqlClient;

namespace ecommerce.WebApi.Config.DI
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var stringConnection = configuration.GetConnectionString("DefaultConnection");
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddScoped<IDbConnection>((con) => new SqlConnection(stringConnection));
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IPedidoApplicationService, PedidoApplicationService>();

            return services;
        }
    }
}
