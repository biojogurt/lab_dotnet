using AutoMapper;
using lab_dotnet.Entities.Models;
using lab_dotnet.Repository;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using Microsoft.Extensions.Logging;

namespace lab_dotnet.Services.Implementation;

public class RequestService : IRequestService
{
    private readonly IPageService<Request, RequestPreviewModel> BaseService;
    private readonly IRepository<Request> Repository;
    private readonly IMapper Mapper;
    private readonly ILogger<RequestService> Logger;

    public RequestService(IPageService<Request, RequestPreviewModel> baseService, IRepository<Request> repository, IMapper mapper, ILogger<RequestService> logger)
    {
        BaseService = baseService;
        Repository = repository;
        Mapper = mapper;
        Logger = logger;
    }

    public void DeleteRequest(Guid id)
    {
        var request = Repository.GetById(id);
        if (request == null)
        {
            Exception ex = new Exception("Request not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        Repository.Delete(request);
    }

    public RequestModel GetRequest(Guid id)
    {
        var request = Repository.GetById(id);
        if (request == null)
        {
            Exception ex = new Exception("Request not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        return Mapper.Map<RequestModel>(request);
    }

    public PageModel<RequestPreviewModel> GetRequests(int limit = 20, int offset = 0)
    {
        var requests = Repository.GetAll();
        return BaseService.CreatePage(requests, limit, offset, x => x.RequestDate);
    }

    public PageModel<RequestPreviewModel> GetRequestsByBorrowerId(Guid borrowerId, int limit = 20, int offset = 0)
    {
        var requests = Repository.GetAll(x => x.BorrowerId == borrowerId);
        return BaseService.CreatePage(requests, limit, offset, x => x.RequestDate);
    }

    public PageModel<RequestPreviewModel> GetRequestsByRequesterId(Guid requesterId, int limit = 20, int offset = 0)
    {
        var requests = Repository.GetAll(x => x.RequesterId == requesterId);
        return BaseService.CreatePage(requests, limit, offset, x => x.RequestDate);
    }

    public RequestModel UpdateRequest(Guid id, UpdateRequestModel request)
    {
        var existingRequest = Repository.GetById(id);
        if (existingRequest == null)
        {
            Exception ex = new Exception("Request not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        if (request.RequesterId != null)
        {
            existingRequest.RequesterId = (Guid)request.RequesterId;
        }

        if (request.BorrowerId != null)
        {
            existingRequest.BorrowerId = (Guid)request.BorrowerId;
        }

        if (request.RequestDate != null)
        {
            existingRequest.RequestDate = (DateTime)request.RequestDate;
        }

        existingRequest = Repository.Save(existingRequest);
        return Mapper.Map<RequestModel>(existingRequest);
    }
}