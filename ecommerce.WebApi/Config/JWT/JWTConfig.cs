using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ecommerce.WebApi.Config.JWT
{
    public static class JWTConfig
    {
        public static IServiceCollection AddJWTConfig(this IServiceCollection services, IConfiguration configuration)
        {           
            var key = Encoding.ASCII.GetBytes(configuration["Jwt:Segredo"]);
            var issuer = configuration["Jwt:Emissor"].ToString();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = false,
                    RequireExpirationTime = false
                };
            });

            return services;
        }
    }
}
