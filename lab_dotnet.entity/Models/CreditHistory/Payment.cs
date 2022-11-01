namespace lab_dotnet.entity.Models.CreditHistory;

public class Payment : BaseEntity
{
    public Guid CreditId { get; set; }
    public DateTime PaymentDate { get; set; }
    public int PaymentAmount { get; set; }
    public int RemainingAmount { get; set; }
    public int Debt { get; set; }

    public virtual Credit Credit { get; set; }
}