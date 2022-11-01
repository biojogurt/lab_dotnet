namespace lab_dotnet.entity.Models.CreditHistory;

public class CreditApplication : BaseEntity
{
    public Guid BorrowerId { get; set; }
    public Guid CreditTypeId { get; set; }
    public Guid CreditorId { get; set; }
    public DateTime ApplicationDate { get; set; }
    public int CreditAmount { get; set; }

    public virtual Borrower Borrower { get; set; }
    public virtual CreditType CreditType { get; set; }
    public virtual Creditor Creditor { get; set; }
    public virtual Credit Credit { get; set; }
}