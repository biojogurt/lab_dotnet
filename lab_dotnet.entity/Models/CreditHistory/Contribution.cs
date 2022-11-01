namespace lab_dotnet.entity.Models.CreditHistory;

public class Contribution : BaseEntity
{
    public Guid ContributorId { get; set; }
    public Guid BorrowerId { get; set; }
    public DateTime ContributionDate { get; set; }

    public virtual Contributor Contributor { get; set; }
    public virtual Borrower Borrower { get; set; }
}