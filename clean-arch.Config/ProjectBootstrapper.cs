using System.Text;
using clean_arch.Application.JWT;
using clean_arch.Application.Order.Services;
using clean_arch.Application.Product;
using clean_arch.Contracts;
using clean_arch.Domain.Order.Repository;
using clean_arch.Domain.Product.Repository;
using clean_arch.Infrastructure;
using clean_arch.Infrastructure.Authentication;
using clean_arch.Infrastructure.Persistent.EF.Order;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration; 

namespace clean_arch.Config;

public static class ProjectBootstrapper 
{
    public static void Configure(IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IOrderRepository, OrderRepository>();
        //services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IOrderService, OrderService>();
        services.AddTransient<IProductService, ProductService>();
        
        services.AddScoped<ISmsService, SmsService>();
        // services.AddSingleton<DbContext>();

        #region JWT Config

        services.Configure<JwtSettings>(
            configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        var jwtSettings = configuration.GetSection(JwtSettings.SectionName).Get<JwtSettings>();
        
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Secret))
                };
            });

        #endregion
    }    
}