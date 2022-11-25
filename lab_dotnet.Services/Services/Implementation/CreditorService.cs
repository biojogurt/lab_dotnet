using AutoMapper;
using lab_dotnet.Entities.Models;
using lab_dotnet.Repository;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using Microsoft.Extensions.Logging;

namespace lab_dotnet.Services.Implementation;

public class CreditorService : ICreditorService
{
    private readonly IPageService<Creditor, CreditorPreviewModel> BaseService;
    private readonly IRepository<Creditor> Repository;
    private readonly IMapper Mapper;
    private readonly ILogger<CreditorService> Logger;

    public CreditorService(IPageService<Creditor, CreditorPreviewModel> baseService, IRepository<Creditor> repository, IMapper mapper, ILogger<CreditorService> logger)
    {
        BaseService = baseService;
        Repository = repository;
        Mapper = mapper;
        Logger = logger;
    }

    public void DeleteCreditor(Guid id)
    {
        var creditor = Repository.GetById(id);
        if (creditor == null)
        {
            Exception ex = new Exception("Creditor not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        Repository.Delete(creditor);
    }

    public CreditorModel GetCreditor(Guid id)
    {
        var creditor = Repository.GetById(id);
        if (creditor == null)
        {
            Exception ex = new Exception("Creditor not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        return Mapper.Map<CreditorModel>(creditor);
    }

    public PageModel<CreditorPreviewModel> GetCreditors(int limit = 20, int offset = 0)
    {
        var creditors = Repository.GetAll();
        return BaseService.CreatePage(creditors, limit, offset, x => x.Name);
    }

    public CreditorModel UpdateCreditor(Guid id, UpdateCreditorModel creditor)
    {
        var existingCreditor = Repository.GetById(id);
        if (existingCreditor == null)
        {
            Exception ex = new Exception("Creditor not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }
        
        if (creditor.Name != null)
        {
            existingCreditor.Name = creditor.Name;
        }

        if (creditor.Inn != null)
        {
            existingCreditor.Inn = creditor.Inn;
        }

        existingCreditor = Repository.Save(existingCreditor);
        return Mapper.Map<CreditorModel>(existingCreditor);
    }
}