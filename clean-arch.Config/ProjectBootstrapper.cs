using clean_arch.Application.Order.Services;
using clean_arch.Application.Product;
using clean_arch.Contracts;
using clean_arch.Domain.Order.Repository;
using clean_arch.Domain.Product.Repository;
using clean_arch.Infrastructure;
using clean_arch.Infrastructure.Persistent.EF.Order;
using Microsoft.Extensions.DependencyInjection;

namespace clean_arch.Config;

public class ProjectBootstrapper
{
    public static void Configure(IServiceCollection services)
    {
        services.AddTransient<IOrderRepository, OrderRepository>();
        //services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IOrderService, OrderService>();
        services.AddTransient<IProductService, ProductService>();
        
        services.AddScoped<ISmsService, SmsService>();
       // services.AddSingleton<DbContext>();
    }    
}