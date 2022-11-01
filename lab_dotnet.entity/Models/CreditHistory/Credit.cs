namespace lab_dotnet.entity.Models.CreditHistory;

public class Credit : BaseEntity
{
    public Guid CreditApplicationId { get; set; }
    public bool IsActive { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int InterestRate { get; set; }

    public virtual CreditApplication CreditApplication { get; set; }
    public virtual ICollection<Payment> Payments { get; set; }
}