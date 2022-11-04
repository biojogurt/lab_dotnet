using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using lab_dotnet.entity.ValidationAttributes;

namespace lab_dotnet.entity.Models.CreditHistory;

public class Borrower : BaseEntity
{
    [Range(1000, 10000)]
    public int PassportSerial { get; set; }
    [Range(100000, 1000000)]
    public int PassportNumber { get; set; }
    public Guid PassportIssuerId { get; set; }
    public DateTime PassportIssueDate { get; set; }
    public string FullName { get; set; }
    [LessThan("PassportIssueDate")]
    public DateTime Birthdate { get; set; }
    public string Inn { get; set; }
    public string Snils { get; set; }
    public string RegistrationAddress { get; set; }
    public string? ResidentialAddress { get; set; }

    [JsonIgnore]
    public virtual PassportIssuer? PassportIssuer { get; set; }
    [JsonIgnore]
    public virtual ICollection<CreditApplication>? CreditApplications { get; set; }
    [JsonIgnore]
    public virtual ICollection<Contribution>? Contributions { get; set; }
    [JsonIgnore]
    public virtual ICollection<Request>? Requests { get; set; }
}