using Solid.Ecommerce.Application.Mappings;
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
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductSubCategoryService, ProductSubCategoryService>();
        services.AddScoped<IProductCategoryService, ProductCategoryService>();
        services.AddScoped<IProductStatusService, ProductStatusService>();

        return services;
    }


    public static IServiceCollection AddAutoMapperService(this IServiceCollection services)
    {
        IMapper mapper;
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        mapper = config.CreateMapper();
        services.AddSingleton(mapper);
        return services;
    }
}
