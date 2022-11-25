using AutoMapper;
using lab_dotnet.Entities.Models;
using lab_dotnet.Repository;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using Microsoft.Extensions.Logging;

namespace lab_dotnet.Services.Implementation;

public class CreditApplicationService : ICreditApplicationService
{
    private readonly IPageService<CreditApplication, CreditApplicationPreviewModel> BaseService;
    private readonly IRepository<CreditApplication> Repository;
    private readonly IMapper Mapper;
    private readonly ILogger<CreditApplicationService> Logger;

    public CreditApplicationService(IPageService<CreditApplication, CreditApplicationPreviewModel> baseService, IRepository<CreditApplication> repository, IMapper mapper, ILogger<CreditApplicationService> logger)
    {
        BaseService = baseService;
        Repository = repository;
        Mapper = mapper;
        Logger = logger;
    }

    public void DeleteCreditApplication(Guid id)
    {
        var application = Repository.GetById(id);
        if (application == null)
        {
            Exception ex = new Exception("Credit application not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        Repository.Delete(application);
    }

    public CreditApplicationModel GetCreditApplication(Guid id)
    {
        var application = Repository.GetById(id);
        if (application == null)
        {
            Exception ex = new Exception("Credit application not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        return Mapper.Map<CreditApplicationModel>(application);
    }

    public PageModel<CreditApplicationPreviewModel> GetCreditApplications(int limit = 20, int offset = 0)
    {
        var applications = Repository.GetAll();
        return BaseService.CreatePage(applications, limit, offset, x => x.ApplicationDate);
    }

    public PageModel<CreditApplicationPreviewModel> GetCreditApplicationsByBorrowerId(Guid borrowerId, int limit = 20, int offset = 0)
    {
        var applications = Repository.GetAll(x => x.BorrowerId == borrowerId);
        return BaseService.CreatePage(applications, limit, offset, x => x.ApplicationDate);
    }

    public PageModel<CreditApplicationPreviewModel> GetCreditApplicationsByCreditorId(Guid creditorId, int limit = 20, int offset = 0)
    {
        var applications = Repository.GetAll(x => x.CreditorId == creditorId);
        return BaseService.CreatePage(applications, limit, offset, x => x.ApplicationDate);
    }

    public PageModel<CreditApplicationPreviewModel> GetCreditApplicationsByCreditTypeId(Guid creditTypeId, int limit = 20, int offset = 0)
    {
        var applications = Repository.GetAll(x => x.CreditTypeId == creditTypeId);
        return BaseService.CreatePage(applications, limit, offset, x => x.ApplicationDate);
    }

    public CreditApplicationModel UpdateCreditApplication(Guid id, UpdateCreditApplicationModel creditApplication)
    {
        var existingApplication = Repository.GetById(id);
        if (existingApplication == null)
        {
            Exception ex = new Exception("Credit application not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        if (creditApplication.BorrowerId != null)
        {
            existingApplication.BorrowerId = (Guid)creditApplication.BorrowerId;
        }

        if (creditApplication.CreditTypeId != null)
        {
            existingApplication.CreditTypeId = (Guid)creditApplication.CreditTypeId;
        }

        if (creditApplication.CreditorId != null)
        {
            existingApplication.CreditorId = (Guid)creditApplication.CreditorId;
        }

        if (creditApplication.ApplicationDate != null)
        {
            existingApplication.ApplicationDate = (DateTime)creditApplication.ApplicationDate;
        }

        if (creditApplication.CreditAmount != null)
        {
            existingApplication.CreditAmount = (int)creditApplication.CreditAmount;
        }

        existingApplication = Repository.Save(existingApplication);
        return Mapper.Map<CreditApplicationModel>(existingApplication);
    }
}