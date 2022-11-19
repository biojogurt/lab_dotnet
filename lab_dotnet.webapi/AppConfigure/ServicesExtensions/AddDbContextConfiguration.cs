using lab_dotnet.Entities;
using Microsoft.EntityFrameworkCore;

namespace lab_dotnet.WebAPI.AppConfigure.ServicesExtensions;

public static partial class ServicesExtensions
{
    /// <summary>
    /// Add dbcontext configuration
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void AddDbContextConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("Context");
        services.AddDbContext<Context>(options =>
        {
            options
                .UseLazyLoadingProxies()
                .UseSqlServer(connectionString, sqlServerOption =>
                        {
                            sqlServerOption.CommandTimeout(60 * 60); // 1 hour
                        });

        });
    }
}