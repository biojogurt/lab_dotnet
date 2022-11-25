namespace lab_dotnet.WebAPI.Models;

public class UpdateContributionRequest
{
    public Guid? ContributorId { get; set; }
    public Guid? BorrowerId { get; set; }
    public DateTime? ContributionDate { get; set; }
}