using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Implementation;
using lab_dotnet.Services.MapperProfile;
using Microsoft.Extensions.DependencyInjection;

namespace lab_dotnet.Services;

public static partial class ServicesExtensions
{
    public static void AddServicesConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ServicesProfile));

        //services
        services.AddScoped<IAppUserService, AppUserService>()
                .AddScoped<IBorrowerService, BorrowerService>()
                .AddScoped<IContributionService, ContributionService>()
                .AddScoped<IContributorService, ContributorService>()
                .AddScoped<ICreditApplicationService, CreditApplicationService>()
                .AddScoped<ICreditorService, CreditorService>()
                .AddScoped<ICreditService, CreditService>()
                .AddScoped<ICreditTypeService, CreditTypeService>()
                .AddScoped<IJobTitleService, JobTitleService>()
                .AddScoped<IPassportIssuerService, PassportIssuerService>()
                .AddScoped<IPaymentService, PaymentService>()
                .AddScoped<IRequesterService, RequesterService>()
                .AddScoped<IRequestService, RequestService>();
    }
}