using lab_dotnet.Services;
using lab_dotnet.Repository;
using lab_dotnet.WebAPI.AppConfiguration.ApplicationExtensions;
using lab_dotnet.WebAPI.AppConfiguration.ServicesExtensions;
using Serilog;

namespace lab_dotnet.WebAPI;

/// <summary>
/// Program entry
/// </summary>
public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.AddSerilogConfiguration();
        builder.Services.AddDbContextConfiguration(new ConfigurationBuilder()
                                                   .AddJsonFile("appsettings.json", optional: false)
                                                   .Build());
        builder.Services.AddVersioningConfiguration();
        builder.Services.AddMapperConfiguration();
        builder.Services.AddControllers();
        builder.Services.AddSwaggerConfiguration();
        builder.Services.AddRepositoryConfiguration();
        builder.Services.AddServicesConfiguration();

        var app = builder.Build();

        app.UseSerilogConfiguration();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerConfiguration();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        try
        {
            Log.Information("Application starting...");
            app.Run();
        }
        catch (Exception ex)
        {
            Log.Error("Application finished with error {error}", ex);
        }
        finally
        {
            Log.Information("Application stopped");
            Log.CloseAndFlush();
        }
    }
}