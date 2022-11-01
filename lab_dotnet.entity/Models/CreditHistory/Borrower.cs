namespace lab_dotnet.entity.Models.CreditHistory;

public class Borrower : BaseEntity
{
    public int PassportSerial { get; set; }
    public int PassportNumber { get; set; }
    public Guid PassportIssuerId { get; set; }
    public DateTime PassportIssueDate { get; set; }
    public string FullName { get; set; }
    public DateTime Birthdate { get; set; }
    public string Inn { get; set; }
    public string Snils { get; set; }
    public string RegistrationAddress { get; set; }
    public string? ResidentialAddress { get; set; }

    public virtual PassportIssuer PassportIssuer { get; set; }
    public virtual ICollection<CreditApplication> CreditApplications { get; set; }
    public virtual ICollection<Contribution> Contributions { get; set; }
    public virtual ICollection<Request> Requests { get; set; }
}