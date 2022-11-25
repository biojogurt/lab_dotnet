using AutoMapper;
using lab_dotnet.Entities.Models;
using lab_dotnet.Repository;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using Microsoft.Extensions.Logging;

namespace lab_dotnet.Services.Implementation;

public class PaymentService : IPaymentService
{
    private readonly IPageService<Payment, PaymentPreviewModel> BaseService;
    private readonly IRepository<Payment> Repository;
    private readonly IMapper Mapper;
    private readonly ILogger<PaymentService> Logger;

    public PaymentService(IPageService<Payment, PaymentPreviewModel> baseService, IRepository<Payment> repository, IMapper mapper,  ILogger<PaymentService> logger)
    {
        BaseService = baseService;
        Repository = repository;
        Mapper = mapper;
        Logger = logger;
    }

    public void DeletePayment(Guid id)
    {
        var payment = Repository.GetById(id);
        if (payment == null)
        {
            Exception ex = new Exception("Payment not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        Repository.Delete(payment);
    }

    public PaymentModel GetPayment(Guid id)
    {
        var payment = Repository.GetById(id);
        if (payment == null)
        {
            Exception ex = new Exception("Payment not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        return Mapper.Map<PaymentModel>(payment);
    }

    public PageModel<PaymentPreviewModel> GetPayments(int limit = 20, int offset = 0)
    {
        var payment = Repository.GetAll();
        return BaseService.CreatePage(payment, limit, offset, x => x.PaymentDate);
    }

    public PageModel<PaymentPreviewModel> GetPaymentsByCreditId(Guid creditId, int limit, int offset)
    {
        var payment = Repository.GetAll(x => x.CreditId == creditId);
        return BaseService.CreatePage(payment, limit, offset, x => x.PaymentDate);
    }

    public PaymentModel UpdatePayment(Guid id, UpdatePaymentModel payment)
    {
        var existingPayment = Repository.GetById(id);
        if (existingPayment == null)
        {
            Exception ex = new Exception("Payment not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        if (payment.CreditId != null)
        {
            existingPayment.CreditId = (Guid)payment.CreditId;
        }

        if (payment.PaymentDate != null)
        {
            existingPayment.PaymentDate = (DateTime)payment.PaymentDate;
        }

        if (payment.PaymentAmount != null)
        {
            existingPayment.PaymentAmount = (int)payment.PaymentAmount;
        }

        if (payment.RemainingAmount != null)
        {
            existingPayment.RemainingAmount = (int)payment.RemainingAmount;
        }

        if (payment.Debt != null)
        {
            existingPayment.Debt = (int)payment.Debt;
        }

        existingPayment = Repository.Save(existingPayment);
        return Mapper.Map<PaymentModel>(existingPayment);
    }
}