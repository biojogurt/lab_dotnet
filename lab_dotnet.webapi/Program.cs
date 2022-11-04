using lab_dotnet.repository;
using lab_dotnet.webapi.AppConfigure.ApplicationExtensions;
using lab_dotnet.webapi.AppConfigure.ServicesExtensions;
using lab_dotnet.entity;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace lab_dotnet.webapi;

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
        builder.Services.AddControllers();
        builder.Services.AddSwaggerConfiguration();

        //temporary
        builder.Services.AddScoped<DbContext, Context>();
        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

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