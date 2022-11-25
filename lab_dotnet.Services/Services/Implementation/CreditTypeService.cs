using AutoMapper;
using lab_dotnet.Entities.Models;
using lab_dotnet.Repository;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using Microsoft.Extensions.Logging;

namespace lab_dotnet.Services.Implementation;

public class CreditTypeService : ICreditTypeService
{
    private readonly IPageService<CreditType, CreditTypePreviewModel> BaseService;
    private readonly IRepository<CreditType> Repository;
    private readonly IMapper Mapper;
    private readonly ILogger<CreditTypeService> Logger;

    public CreditTypeService(IPageService<CreditType, CreditTypePreviewModel> baseService, IRepository<CreditType> repository, IMapper mapper, ILogger<CreditTypeService> logger)
    {
        BaseService = baseService;
        Repository = repository;
        Mapper = mapper;
        Logger = logger;
    }

    public void DeleteCreditType(Guid id)
    {
        var creditType = Repository.GetById(id);
        if (creditType == null)
        {
            Exception ex = new Exception("Credit type not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        Repository.Delete(creditType);
    }

    public CreditTypeModel GetCreditType(Guid id)
    {
        var creditType = Repository.GetById(id);
        if (creditType == null)
        {
            Exception ex = new Exception("Credit type not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        return Mapper.Map<CreditTypeModel>(creditType);
    }

    public PageModel<CreditTypePreviewModel> GetCreditTypes(int limit = 20, int offset = 0)
    {
        var creditType = Repository.GetAll();
        return BaseService.CreatePage(creditType, limit, offset, x => x.Name);
    }

    public CreditTypeModel UpdateCreditType(Guid id, UpdateCreditTypeModel creditType)
    {
        var existingCreditType = Repository.GetById(id);
        if (existingCreditType == null)
        {
            Exception ex = new Exception("Credit type not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        if (creditType.Name != null)
        {
            existingCreditType.Name = (string)creditType.Name;
        }

        existingCreditType = Repository.Save(existingCreditType);
        return Mapper.Map<CreditTypeModel>(existingCreditType);
    }
}