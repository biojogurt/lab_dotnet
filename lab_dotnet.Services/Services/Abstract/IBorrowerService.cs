using lab_dotnet.Services.Models;

namespace lab_dotnet.Services.Abstract;

public interface IBorrowerService
{
    BorrowerModel GetBorrowerById(Guid id);

    BorrowerModel GetBorrowerByPassport(PassportModel passport);

    BorrowerModel UpdateBorrower(Guid id, UpdateBorrowerModel borrower);

    void DeleteBorrower(Guid id);

    PageModel<BorrowerPreviewModel> GetBorrowers(int limit = 20, int offset = 0);
}