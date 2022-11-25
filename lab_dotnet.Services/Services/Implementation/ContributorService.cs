using AutoMapper;
using lab_dotnet.Entities.Models;
using lab_dotnet.Repository;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using Microsoft.Extensions.Logging;

namespace lab_dotnet.Services.Implementation;

public class ContributorService : IContributorService
{
    private readonly IPageService<Contributor, ContributorPreviewModel> BaseService;
    private readonly IRepository<Contributor> Repository;
    private readonly IMapper Mapper;
    private readonly ILogger<ContributorService> Logger;

    public ContributorService(IPageService<Contributor, ContributorPreviewModel> baseService, IRepository<Contributor> repository, IMapper mapper, ILogger<ContributorService> logger)
    {
        BaseService = baseService;
        Repository = repository;
        Mapper = mapper;
        Logger = logger;
    }

    public void DeleteContributor(Guid id)
    {
        var contributor = Repository.GetById(id);
        if (contributor == null)
        {
            Exception ex = new Exception("Contributor not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        Repository.Delete(contributor);
    }

    public ContributorModel GetContributor(Guid id)
    {
        var contributor = Repository.GetById(id);
        if (contributor == null)
        {
            Exception ex = new Exception("Contributor not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        return Mapper.Map<ContributorModel>(contributor);
    }

    public PageModel<ContributorPreviewModel> GetContributors(int limit = 20, int offset = 0)
    {
        var contributors = Repository.GetAll();
        return BaseService.CreatePage(contributors, limit, offset, x => x.Name);
    }

    public ContributorModel UpdateContributor(Guid id, UpdateContributorModel contributor)
    {
        var existingContributor = Repository.GetById(id);
        if (existingContributor == null)
        {
            Exception ex = new Exception("Contributor not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }
        
        if (contributor.Name != null)
        {
            existingContributor.Name = contributor.Name;
        }

        if (contributor.Inn != null)
        {
            existingContributor.Inn = contributor.Inn;
        }

        existingContributor = Repository.Save(existingContributor);
        return Mapper.Map<ContributorModel>(existingContributor);
    }
}