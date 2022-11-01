using Serilog;

namespace lab_dotnet.webapi.AppConfigure.ApplicationExtensions;

public static partial class AppExtensions
{
    /// <summary>
    /// Use serilog configuration
    /// </summary>
    /// <param name="app"></param>
    public static void UseSerilogConfiguration(this IApplicationBuilder app)
    {
        app.UseSerilogRequestLogging();
    }
}