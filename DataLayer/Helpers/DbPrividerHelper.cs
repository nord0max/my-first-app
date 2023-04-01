using Microsoft.Extensions.DependencyInjection;

namespace WebApplication1.Model.Helpers;

public static class DbProviderHelper
{
    public static void AddDbProvider(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<ApplicationContext>(x=>new ApplicationContext(connectionString));
    }
}