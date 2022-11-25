using AutoMapper;
using lab_dotnet.Entities.Models;
using lab_dotnet.Repository;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using Microsoft.Extensions.Logging;

namespace lab_dotnet.Services.Implementation;

public class ContributionService : IContributionService
{
    private readonly IPageService<Contribution, ContributionPreviewModel> BaseService;
    private readonly IRepository<Contribution> Repository;
    private readonly IMapper Mapper;
    private readonly ILogger<ContributionService> Logger;

    public ContributionService(IPageService<Contribution, ContributionPreviewModel> baseService, IRepository<Contribution> repository, IMapper mapper, ILogger<ContributionService> logger)
    {
        BaseService = baseService;
        Repository = repository;
        Mapper = mapper;
        Logger = logger;
    }

    public void DeleteContribution(Guid id)
    {
        var contribution = Repository.GetById(id);
        if (contribution == null)
        {
            Exception ex = new Exception("Contribution not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        Repository.Delete(contribution);
    }

    public ContributionModel GetContribution(Guid id)
    {
        var contribution = Repository.GetById(id);
        if (contribution == null)
        {
            Exception ex = new Exception("Contribution not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        return Mapper.Map<ContributionModel>(contribution);
    }

    public PageModel<ContributionPreviewModel> GetContributions(int limit = 20, int offset = 0)
    {
        var contributions = Repository.GetAll();
        return BaseService.CreatePage(contributions, limit, offset, x => x.ContributionDate);
    }

    public PageModel<ContributionPreviewModel> GetContributionsByBorrowerId(Guid borrowerId, int limit = 20, int offset = 0)
    {
        var contributions = Repository.GetAll(x => x.BorrowerId == borrowerId);
        return BaseService.CreatePage(contributions, limit, offset, x => x.ContributionDate);
    }

    public PageModel<ContributionPreviewModel> GetContributionsByContributorId(Guid contributorId, int limit = 20, int offset = 0)
    {
        var contributions = Repository.GetAll(x => x.ContributorId == contributorId);
        return BaseService.CreatePage(contributions, limit, offset, x => x.ContributionDate);
    }

    public ContributionModel UpdateContribution(Guid id, UpdateContributionModel contribution)
    {
        var existingContribution = Repository.GetById(id);
        if (existingContribution == null)
        {
            Exception ex = new Exception("Contribution not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        if (contribution.ContributorId != null)
        {
            existingContribution.ContributorId = (Guid)contribution.ContributorId;
        }

        if (contribution.BorrowerId != null)
        {
            existingContribution.BorrowerId = (Guid)contribution.BorrowerId;
        }

        if (contribution.ContributionDate != null)
        {
            existingContribution.ContributionDate = (DateTime)contribution.ContributionDate;
        }

        existingContribution = Repository.Save(existingContribution);
        return Mapper.Map<ContributionModel>(existingContribution);
    }
}