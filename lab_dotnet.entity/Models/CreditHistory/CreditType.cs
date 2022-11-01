namespace lab_dotnet.entity.Models.CreditHistory;

public class CreditType : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<CreditApplication> CreditApplications { get; set; }
}