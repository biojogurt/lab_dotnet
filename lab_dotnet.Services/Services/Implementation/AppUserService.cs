using AutoMapper;
using lab_dotnet.Entities.Models;
using lab_dotnet.Repository;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using Microsoft.Extensions.Logging;

namespace lab_dotnet.Services.Implementation;

public class AppUserService : IAppUserService
{
    private readonly IPageService<AppUser, AppUserPreviewModel> PageService;
    private readonly IRepository<AppUser> Repository;
    private readonly IMapper Mapper;
    private readonly ILogger<AppUserService> Logger;

    public AppUserService(IPageService<AppUser, AppUserPreviewModel> pageService,
                          IRepository<AppUser> repository,
                          IMapper mapper,
                          ILogger<AppUserService> logger)
    {
        PageService = pageService;
        Repository = repository;
        Mapper = mapper;
        Logger = logger;
    }

    public void DeleteAppUser(Guid id)
    {
        var user = Repository.GetById(id);
        if (user == null)
        {
            Exception ex = new Exception("User not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        Repository.Delete(user);
    }

    public AppUserModel GetAppUser(Guid id)
    {
        var user = Repository.GetById(id);
        if (user == null)
        {
            Exception ex = new Exception("User not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        return Mapper.Map<AppUserModel>(user);
    }

    public PageModel<AppUserPreviewModel> GetAppUsers(int limit = 20, int offset = 0)
    {
        var appUsers = Repository.GetAll();
        return PageService.CreatePage(appUsers, limit, offset, x => x.FullName);
    }

    public PageModel<AppUserPreviewModel> GetAppUsersByAccessLevel(int accessLevel, int limit = 20, int offset = 0)
    {
        var appUsers = Repository.GetAll(x => x.AccessLevel == accessLevel);
        return PageService.CreatePage(appUsers, limit, offset, x => x.FullName);
    }

    public PageModel<AppUserPreviewModel> GetAppUsersByJobTitleId(Guid jobTitleId, int limit = 20, int offset = 0)
    {
        var appUsers = Repository.GetAll(x => x.JobTitleId == jobTitleId);
        return PageService.CreatePage(appUsers, limit, offset, x => x.FullName);
    }

    public AppUserModel UpdateAppUser(Guid id, UpdateAppUserModel appUser)
    {
        var existingUser = Repository.GetById(id);
        if (existingUser == null)
        {
            Exception ex = new Exception("User not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        if (appUser.FullName != null)
        {
            existingUser.FullName = appUser.FullName;
        }

        if (appUser.Email != null)
        {
            existingUser.Email = appUser.Email;
        }

        if (appUser.PasswordHash != null)
        {
            existingUser.PasswordHash = appUser.PasswordHash;
        }

        existingUser = Repository.Save(existingUser);
        return Mapper.Map<AppUserModel>(existingUser);
    }
}