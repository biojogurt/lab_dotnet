using AutoMapper;
using lab_dotnet.Entities.Models;
using lab_dotnet.Repository;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using Microsoft.Extensions.Logging;

namespace lab_dotnet.Services.Implementation;

public class CreditService : ICreditService
{
    private readonly IPageService<Credit, CreditPreviewModel> BaseService;
    private readonly IRepository<Credit> Repository;
    private readonly IMapper Mapper;
    private readonly ILogger<CreditService> Logger;

    public CreditService(IPageService<Credit, CreditPreviewModel> baseService, IRepository<Credit> repository, IMapper mapper, ILogger<CreditService> logger)
    {
        BaseService = baseService;
        Repository = repository;
        Mapper = mapper;
        Logger = logger;
    }

    public void DeleteCredit(Guid id)
    {
        var credit = Repository.GetById(id);
        if (credit == null)
        {
            Exception ex = new Exception("Credit not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        Repository.Delete(credit);
    }

    public CreditModel GetCredit(Guid id)
    {
        var credit = Repository.GetAll(x => x.CreditApplicationId == id).FirstOrDefault();
        if (credit == null)
        {
            Exception ex = new Exception("Credit not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        return Mapper.Map<CreditModel>(credit);
    }

    public PageModel<CreditPreviewModel> GetCredits(int limit = 20, int offset = 0)
    {
        var credits = Repository.GetAll();
        return BaseService.CreatePage(credits, limit, offset, x => x.StartDate);
    }

    public PageModel<CreditPreviewModel> GetCreditsByBorrowerId(Guid borrowerId, int limit = 20, int offset = 0)
    {
        var credits = Repository.GetAll(x => x.CreditApplication.BorrowerId == borrowerId);
        return BaseService.CreatePage(credits, limit, offset, x => x.StartDate);
    }

    public CreditModel UpdateCredit(Guid id, UpdateCreditModel credit)
    {
        var existingCredit = Repository.GetById(id);
        if (existingCredit == null)
        {
            Exception ex = new Exception("Credit not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }
        
        if (credit.CreditApplicationId != null)
        {
            existingCredit.CreditApplicationId = (Guid)credit.CreditApplicationId;
        }

        if (credit.IsActive != null)
        {
            existingCredit.IsActive = (bool)credit.IsActive;
        }

        if (credit.StartDate != null)
        {
            existingCredit.StartDate = (DateTime)credit.StartDate;
        }

        if (credit.EndDate != null)
        {
            existingCredit.EndDate = credit.EndDate;
        }

        if (credit.InterestRate != null)
        {
            existingCredit.InterestRate = (int)credit.InterestRate;
        }

        existingCredit = Repository.Save(existingCredit);
        return Mapper.Map<CreditModel>(existingCredit);
    }
}