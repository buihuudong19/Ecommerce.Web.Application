
using Solid.Ecommerce.Services.Services;

namespace Ecommerce.Web;
public class Startup
{
    public IConfiguration Configuration { get;}

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
        services.AddRazorPages();

        services.AddHttpContextAccessor();
        services.AddTransient<IActionContextAccessor, ActionContextAccessor>();
        services.AddScoped<IRazorRenderService, RazorRenderService>();
        /*Goi dich vu ket noi xuong database => entity framework core*/
        services.EcommerceInfrastructureDatabase(Configuration);
        services.AddDataServices();
        services.AddAutoMapperService();
        
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (!env.IsDevelopment())
        {
            app.UseHsts();
        }
        app.UseRouting(); // start endpoint routing
        app.UseHttpsRedirection();
        app.UseDefaultFiles(); //index.cshtml, home.cshtml
        app.UseStaticFiles();
        app.UseAuthentication();    
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            endpoints.MapGet("/hello", () => "Hello World!");
        });
    }
}
