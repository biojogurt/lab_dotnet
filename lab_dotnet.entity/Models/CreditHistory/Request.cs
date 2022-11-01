namespace lab_dotnet.entity.Models.CreditHistory;

public class Request : BaseEntity
{
    public Guid RequesterId { get; set; }
    public Guid BorrowerId { get; set; }
    public DateTime RequestDate { get; set; }

    public virtual Requester Requester { get; set; }
    public virtual Borrower Borrower { get; set; }
}