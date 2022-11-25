using AutoMapper;
using lab_dotnet.WebAPI.Models;
using lab_dotnet.Services.Models;

namespace lab_dotnet.WebAPI.MapperProfile;

public class PresentationProfile : Profile
{
    public PresentationProfile()
    {
        #region Paging

        CreateMap(typeof(PageModel<>), typeof(PageResponse<>));

        #endregion Paging

        #region Base

        CreateMap<BaseModel, BaseResponse>();

        #endregion Base

        #region AppUser

        CreateMap<AppUserModel, AppUserResponse>();
        CreateMap<UpdateAppUserRequest, UpdateAppUserModel>();
        CreateMap<AppUserPreviewModel, AppUserPreviewResponse>();

        #endregion AppUser

        #region Borrower

        CreateMap<BorrowerModel, BorrowerResponse>();
        CreateMap<UpdateBorrowerRequest, UpdateBorrowerModel>();
        CreateMap<BorrowerPreviewModel, BorrowerPreviewResponse>();

        #endregion Borrower

        #region Contribution

        CreateMap<ContributionModel, ContributionResponse>();
        CreateMap<UpdateContributionRequest, UpdateContributionModel>();
        CreateMap<ContributionPreviewModel, ContributionPreviewResponse>();

        #endregion Contribution

        #region Contributor

        CreateMap<ContributorModel, ContributorResponse>();
        CreateMap<UpdateContributorRequest, UpdateContributorModel>();
        CreateMap<ContributorPreviewModel, ContributorPreviewResponse>();

        #endregion Contributor

        #region Credit

        CreateMap<CreditModel, CreditResponse>();
        CreateMap<UpdateCreditRequest, UpdateCreditModel>();
        CreateMap<CreditPreviewModel, CreditPreviewResponse>();

        #endregion Credit

        #region CreditApplication

        CreateMap<CreditApplicationModel, CreditApplicationResponse>();
        CreateMap<UpdateCreditApplicationRequest, UpdateCreditApplicationModel>();
        CreateMap<CreditApplicationPreviewModel, CreditApplicationPreviewResponse>();

        #endregion CreditApplication

        #region Creditor

        CreateMap<CreditorModel, CreditorResponse>();
        CreateMap<UpdateCreditorRequest, UpdateCreditorModel>();
        CreateMap<CreditorPreviewModel, CreditorPreviewResponse>();

        #endregion Creditor

        #region CreditType

        CreateMap<CreditTypeModel, CreditTypeResponse>();
        CreateMap<UpdateCreditTypeRequest, UpdateCreditTypeModel>();
        CreateMap<CreditTypePreviewModel, CreditTypePreviewResponse>();

        #endregion CreditType

        #region JobTitle

        CreateMap<JobTitleModel, JobTitleResponse>();
        CreateMap<UpdateJobTitleRequest, UpdateJobTitleModel>();
        CreateMap<JobTitlePreviewModel, JobTitlePreviewResponse>();

        #endregion JobTitle

        #region PassportIssuer

        CreateMap<PassportIssuerModel, PassportIssuerResponse>();
        CreateMap<UpdatePassportIssuerRequest, UpdatePassportIssuerModel>();
        CreateMap<PassportIssuerPreviewModel, PassportIssuerPreviewResponse>();

        #endregion PassportIssuer

        #region Payment

        CreateMap<PaymentModel, PaymentResponse>();
        CreateMap<UpdatePaymentRequest, UpdatePaymentModel>();
        CreateMap<PaymentPreviewModel, PaymentPreviewResponse>();

        #endregion Payment

        #region Request

        CreateMap<RequestModel, RequestResponse>();
        CreateMap<UpdateRequestRequest, UpdateRequestModel>();
        CreateMap<RequestPreviewModel, RequestPreviewResponse>();

        #endregion Request

        #region Requester

        CreateMap<RequesterModel, RequesterResponse>();
        CreateMap<UpdateRequesterRequest, UpdateRequesterModel>();
        CreateMap<RequesterPreviewModel, RequesterPreviewResponse>();

        #endregion Requester
    }
}