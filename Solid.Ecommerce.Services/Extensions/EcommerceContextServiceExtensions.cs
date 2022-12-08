using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Solid.Ecommerce.Infrastructure.Context;
using Solid.Ecommerce.Application.Interfaces.Common;
using Solid.Ecommerce.Application.Interfaces.Repositories;
using Solid.Ecommerce.Infrastructure.Repositories;
using Solid.Ecommerce.Services.Services;
namespace Solid.Ecommerce.Services.Extensions;
public static class EcommerceContextServiceExtensions
{
    /*Dich vu ket noi xuong csdl thong qua entity framework core*/
    public static IServiceCollection EcommerceInfrastructureDatabase(
        this IServiceCollection services, IConfiguration config)
    {
        /*bien ket noi xuong db nhu la dich vu*/
        services.AddDbContext<SolidEcommerceDbContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("SolidEcommerceDb"), sqlOptions => sqlOptions.CommandTimeout(120));
            /*Su dung ky thuat loading luoi (lazyloading) khi thao tac voi DB*/
            options.UseLazyLoadingProxies();
        });

        /*khoi tao doi tuong co cac kieu ma minh mong muon => containers*/
        services.AddScoped<Func<SolidEcommerceDbContext>>(
            (
                provider) => ()=> provider.GetService<SolidEcommerceDbContext>()
            
            );
        services.AddScoped<DbFactoryContext>();
        services.AddScoped<IApplicationDBContext, ApplicationDbContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
    public static IServiceCollection AddDataServices(this IServiceCollection services)
    {
        return services.AddScoped<IProductService, ProductService>();
    }
}
